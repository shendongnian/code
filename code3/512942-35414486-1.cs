        public static System.Drawing.Image AforgeAutoCrop(Bitmap selectedImage)
        {
            Bitmap autoCropImage = null;
            try
            {
                autoCropImage = selectedImage;
                // create grayscale filter (BT709)
                Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
                Bitmap grayImage = filter.Apply(autoCropImage);
                // create instance of skew checker
                DocumentSkewChecker skewChecker = new DocumentSkewChecker();
                // get documents skew angle
                double angle = 0; // skewChecker.GetSkewAngle(grayImage);
                // create rotation filter
                RotateBilinear rotationFilter = new RotateBilinear(-angle);
                rotationFilter.FillColor = Color.White;
                // rotate image applying the filter
                Bitmap rotatedImage = rotationFilter.Apply(grayImage);
                new ContrastStretch().ApplyInPlace(rotatedImage);
                new Threshold(25).ApplyInPlace(rotatedImage);
                BlobCounter bc = new BlobCounter();
                bc.FilterBlobs = true;
                // bc.MinWidth = 500;
                //bc.MinHeight = 500;
                bc.ProcessImage(rotatedImage);
                Rectangle[] rects = bc.GetObjectsRectangles();
                if (rects.Length == 0)
                {
                    // CAN'T CROP
                }
                else if (rects.Length == 1)
                {
                    autoCropImage = autoCropImage.Clone(rects[0], autoCropImage.PixelFormat); ;
                }
                else if (rects.Length > 1)
                {
                    // get largets rect
                    Console.WriteLine("Using largest rectangle found in image ");
                    var r2 = rects.OrderByDescending(r => r.Height * r.Width).ToList();
                    autoCropImage = autoCropImage.Clone(r2[0], autoCropImage.PixelFormat);
                }
                else
                {
                    Console.WriteLine("Huh? on image ");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //CAN'T CROP
            }
            return autoCropImage;
        }
