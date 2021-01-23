            using (System.Drawing.Image image = System.Drawing.Bitmap.FromStream(fs))
            {
                wEmu = (int)Math.Round((decimal)image.Width * 9525);    // image width size (in pixels) is converted into Emu's. 1px = 9525 emu.
                hEmu = (int)Math.Round((decimal)image.Height * 9525);   // image height size (in pixels) is converted into Emu's.
               // convertedWidth = do your required conversion here (e.g width 1024*9525)
               // convertedHeight = e.g 786*9525
               if(wEmu > convertedWidth || hEmu > convertedHeight)
               {
                    // here you can throw your exception
               }
            }
