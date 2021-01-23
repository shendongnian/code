    public List<Rectangle> detect(Bitmap inputImage)
            {
                inImage = new Image<Bgr, byte>(inputImage);
                grayImage = inImage.Convert<Gray, Byte>();
    
                List<Rectangle> faceRects = new List<Rectangle>();
                
                var faces = grayImage.DetectHaarCascade(haar, 1.1, 1, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(inImage.Width, inImage.Height))[0];
               
                grayImage.Dispose();
                
                foreach (var face in faces)
                {
                    faceRects.Add(face.rect);                
                }
    
                inImage.Dispose();
                return faceRects;
            }
