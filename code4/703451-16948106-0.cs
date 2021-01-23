    //Save to file
                    if (skeletonFrame != null)
                    {
                        RenderTargetBitmap bmp = new RenderTargetBitmap(800, 600, 96, 96, PixelFormats.Pbgra32);
                        bmp.Render(window.image);
                        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                        // create frame from the writable bitmap and add to encoder
                        if (skeletonFrame.Timestamp - lastTime > 90)
                        {
                            encoder.Frames.Add(BitmapFrame.Create(bmp));
                            string myPhotos = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                            string path = "C:your\\directory\\here" + skeletonFrame.Timestamp + ".jpg";
                            using (FileStream fs = new FileStream(path, FileMode.Create))
                            {
                                encoder.Save(fs);
                            }
                            lastTime = skeletonFrame.Timestamp;
                        }
                    }
