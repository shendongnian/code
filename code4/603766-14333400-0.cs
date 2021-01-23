    Image mask = Image.FromFile("mask.png");
    public Bitmap getFacedBitmap(Bitmap bbb)
        {
            using (Image<Bgr, byte> nextFrame = new Image<Bgr, byte>(bbb))
            {
                if (nextFrame != null)
                {
                    // there's only one channel (greyscale), hence the zero index
                    //var faces = nextFrame.DetectHaarCascade(haar)[0];
                    Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
                    //Image<Gray, Byte> gray = nextFrame.Convert<Gray, Byte>();
                    var faces = grayframe.DetectHaarCascade(haar, 1.3, 2, HAAR_DETECTION_TYPE.SCALE_IMAGE, new Size(nextFrame.Width / 8, nextFrame.Height / 8))[0];
                    if (faces.Length > 0)
                    {
                       foreach (var face in faces)
                      {
                          //ImageFrame.Draw(face.rect, new Bgr(Color.Green), 2);
                          //                     
                          using(Graphics g = Graphics.FromImage(bbb))
                         {
                           g.DrawImage(mask,face.rect);
                           g.Save()
                         }
                      }
                
                   }
               }
           }
        retun bbb;
      }
