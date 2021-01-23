            private void DetectFace()
        {
            var failerCounter = 0;
            var cameraHandler = 0;
            try
            {
                const int failerLimit = 2;
                int failerLimitFaceDetection = Properties.Settings.Default.NotDetectedLimit;
                float similarityMinimum = Properties.Settings.Default.SimilarityLimit;
                var r = FSDKCam.OpenVideoCamera(ref CameraName, ref cameraHandler);
                if (r != FSDK.FSDKE_OK)
                {
                    MessageBox.Show(StringHelper.ErrorCamera);
                }
                FSDK.SetFaceDetectionParameters(
                    Properties.Settings.Default.DetectionHandleArbitaryRotations,
                    Properties.Settings.Default.DetectionDetermineFaceRotationAngle,
                    Properties.Settings.Default.DetectionInternalResizeWidth);
                FSDK.SetFaceDetectionThreshold(Properties.Settings.Default.DetectionFaceDetectionThreshold);
                while (IsFaceDetectionActive)
                {
                    var imageHandle = 0;
                    if (FSDK.FSDKE_OK != FSDKCam.GrabFrame(cameraHandler, ref imageHandle))
                    {
                        Application.Current.Dispatcher.Invoke(delegate { }, DispatcherPriority.Background);
                        continue;
                    }
                    var image = new FSDK.CImage(imageHandle);
                    var frameImage = image.ToCLRImage();
                    FaceContent = frameImage;
                    var gr = Graphics.FromImage(frameImage);
                    var facePosition = image.DetectFace();
                    IsFaceDetected = facePosition.w != 0;
                    if (!IsFaceDetected)
                    {
                        if (failerCounter++ > failerLimitFaceDetection)
                        {
                            failerCounter = 0;
                            OnFaceNotDetected();
                        }
                    }
                    // if a face is detected, we detect facial features
                    if (IsFaceDetected)
                    {
                        var facialFeatures = image.DetectFacialFeaturesInRegion(ref facePosition);
                        SmoothFacialFeatures(ref facialFeatures);
                        FaceTemplate = image.GetFaceTemplate();
                        // Similarity = 0.5f -> fin the right value ....
                        IsFaceRecognized = FaceMetricHandler.LooksLike(FaceTemplate, similarityMinimum).Any();
                        if (IsFaceRecognized)
                        {
                            foreach (var match in FaceMetricHandler.LooksLike(FaceTemplate, similarityMinimum))
                            {
                                failerCounter = 0;
                                GreetingMessage = match.Name;
                                IsFaceDetectionActive = false;
                                OnFaceRecognized();
                                break;
                            }
                        }
                        else
                        {
                            if (failerCounter++ > failerLimit)
                            {
                                failerCounter = 0;
                                IsFaceDetectionActive = false;
                                OnFaceNotRecognized();
                            }
                        }
                        if (IsFaceFrameActive)
                        {
                            gr.DrawRectangle(Pens.Red, facePosition.xc - 2*facePosition.w/3,
                                             facePosition.yc - facePosition.w/2,
                                             4*facePosition.w/3, 4*facePosition.w/3);
                        }
                    }
                    else
                    {
                        ResetSmoothing();
                    }
                    FaceContent = frameImage;
                    GC.Collect();
                    Application.Current.Dispatcher.Invoke(delegate { }, DispatcherPriority.Background);
                }
            }
            catch(Exception e)
            {
                logger.Fatal(e.Message);
                InitializeCamera();
            }
            finally
            {
                FSDKCam.CloseVideoCamera(cameraHandler);
                FSDKCam.FinalizeCapturing();
            }
        }
