    var faces = grayframe.DetectHaarCascade(
                                haar, 1.4, 4,
                                HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                new Size(nextFrame.Width / 8, nextFrame.Height / 8)
                                )[0];
     foreach (var f in faces)
     {
        //draw the face detected in the 0th (gray) channel with blue color
        image.Draw(f.rect, new Bgr(Color.Blue), 2);
 
 
         //Set the region of interest on the faces
         gray.ROI = f.rect;
         var mouthsDetected = gray.DetectHaarCascade(mouth, 
                                  1.1, 10, 
                                  Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, 
                                  new Size(20, 20));
         gray.ROI = Rectangle.Empty;
 
         foreach (var m in mouthsDetected [0])
         {
              Rectangle mouthRect = m.rect;
              mouthRect.Offset(f.rect.X, f.rect.Y);
              image.Draw(mouthRect , new Bgr(Color.Red), 2);
         }
       }
