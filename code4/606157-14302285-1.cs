     int halfheight = facesnap.Height/2;
                        int start = facesnap.X;
                        int start1 = facesnap.Y;
                        
                        Rectangle top = new Rectangle(start,start1,facesnap.Width,halfheight);
                        int start2 = top.Bottom;
                        
                        Rectangle bottom = new Rectangle(start, start2, facesnap.Width, halfheight);
                        nextFrame.Draw(bottom, new Bgr(Color.Yellow), 2);
                        //Set the region of interest on the faces
                        gray.ROI = bottom;
                        MCvAvgComp[][] mouthsDetected = gray.DetectHaarCascade(mouth,
                                                        1.1, 10,
                                                      Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                                        new Size(20, 20));
