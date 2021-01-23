    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    
    namespace Studio.Utilities
    {
        public class ImageResizer
        {
            public void ResizeImage(string origFileLocation, string newFileLocation, string origFileName, string newFileName, int newWidth, int maxHeight, bool resizeIfWider)
            {
                System.Drawing.Image FullSizeImage = System.Drawing.Image.FromFile(origFileLocation + origFileName);
                // Ensure the generated thumbnail is not being used by rotating it 360 degrees
                FullSizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
                FullSizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
    
                if (resizeIfWider)
                {
                    if (FullSizeImage.Width <= newWidth)
                    {
                        //newWidth = FullSizeImage.Width;
                    }
                }
    
                int newHeight = FullSizeImage.Height * newWidth / FullSizeImage.Width;
                if (newHeight > maxHeight) // Height resize if necessary
                {
                    //newWidth = FullSizeImage.Width * maxHeight / FullSizeImage.Height;
                    newHeight = maxHeight;
                }
                newHeight = maxHeight;
                // Create the new image with the sizes we've calculated
                System.Drawing.Image NewImage = FullSizeImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);
                FullSizeImage.Dispose();
                NewImage.Save(newFileLocation + newFileName);
            }
            public void ResizeImageAndRatio(string origFileLocation, string newFileLocation, string origFileName, string newFileName, int newWidth, int newHeight, bool resizeIfWider)
            {
                
                System.Drawing.Image initImage = System.Drawing.Image.FromFile(origFileLocation + origFileName);
                int templateWidth = newWidth;
                int templateHeight = newHeight;
                    double templateRate = double.Parse(templateWidth.ToString()) / templateHeight;
                    double initRate = double.Parse(initImage.Width.ToString()) / initImage.Height;
                    if (templateRate == initRate)
                    {
    
                        System.Drawing.Image templateImage = new System.Drawing.Bitmap(templateWidth, templateHeight);
                        System.Drawing.Graphics templateG = System.Drawing.Graphics.FromImage(templateImage);
                        templateG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        templateG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        templateG.Clear(Color.White);
                        templateG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, templateWidth, templateHeight), new System.Drawing.Rectangle(0, 0, initImage.Width, initImage.Height), System.Drawing.GraphicsUnit.Pixel);
                        templateImage.Save(newFileLocation + newFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
    
                    else
                    {
    
                        System.Drawing.Image pickedImage = null;
                        System.Drawing.Graphics pickedG = null;
    
    
                        Rectangle fromR = new Rectangle(0, 0, 0, 0);
                        Rectangle toR = new Rectangle(0, 0, 0, 0);
    
    
                        if (templateRate > initRate)
                        {
    
                            pickedImage = new System.Drawing.Bitmap(initImage.Width, int.Parse(Math.Floor(initImage.Width / templateRate).ToString()));
                            pickedG = System.Drawing.Graphics.FromImage(pickedImage);
    
    
                            fromR.X = 0;
                            fromR.Y = int.Parse(Math.Floor((initImage.Height - initImage.Width / templateRate) / 2).ToString());
                            fromR.Width = initImage.Width;
                            fromR.Height = int.Parse(Math.Floor(initImage.Width / templateRate).ToString());
    
    
                            toR.X = 0;
                            toR.Y = 0;
                            toR.Width = initImage.Width;
                            toR.Height = int.Parse(Math.Floor(initImage.Width / templateRate).ToString());
                        }
    
                        else
                        {
                            pickedImage = new System.Drawing.Bitmap(int.Parse(Math.Floor(initImage.Height * templateRate).ToString()), initImage.Height);
                            pickedG = System.Drawing.Graphics.FromImage(pickedImage);
    
                            fromR.X = int.Parse(Math.Floor((initImage.Width - initImage.Height * templateRate) / 2).ToString());
                            fromR.Y = 0;
                            fromR.Width = int.Parse(Math.Floor(initImage.Height * templateRate).ToString());
                            fromR.Height = initImage.Height;
    
                            toR.X = 0;
                            toR.Y = 0;
                            toR.Width = int.Parse(Math.Floor(initImage.Height * templateRate).ToString());
                            toR.Height = initImage.Height;
                        }
    
    
                        pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    
    
                        pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
    
    
                        System.Drawing.Image templateImage = new System.Drawing.Bitmap(templateWidth, templateHeight);
                        System.Drawing.Graphics templateG = System.Drawing.Graphics.FromImage(templateImage);
                        templateG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        templateG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        templateG.Clear(Color.White);
                        templateG.DrawImage(pickedImage, new System.Drawing.Rectangle(0, 0, templateWidth, templateHeight), new System.Drawing.Rectangle(0, 0, pickedImage.Width, pickedImage.Height), System.Drawing.GraphicsUnit.Pixel);
                        templateImage.Save(newFileLocation + newFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
    
    
                        templateG.Dispose();
                        templateImage.Dispose();
    
                        pickedG.Dispose();
                        pickedImage.Dispose();
                    }
                    initImage.Dispose();
                }
     
        }
    }
