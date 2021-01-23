                //Convert it to Grayscale
                gray = currentFrame.Convert<Gray, Byte>();
                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                                                      new System.Drawing.Size(20, 20));
