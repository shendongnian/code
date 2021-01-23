       if (PInvoke.OpenClipboard(pictureBox_Sketch.Handle))
            {
                if (PInvoke.IsClipboardFormatAvailable(14))
                {
                    IntPtr ptr = PInvoke.GetClipboardData(14);
                    if (!ptr.Equals(new IntPtr(0)))
                    {
                        Metafile metafile = new Metafile(ptr, true);
                        metafile.Save("C:\\ruta\\Images\\ModelGraph.png", System.Drawing.Imaging.ImageFormat.Png);
                        //HyperLink1.NavigateUrl = "Images\\ModelGraph.png";
                        // Image1.ImageUrl = "Images\\ModelGraph.emf";
                        //Set the Image Property of PictureBox 
                    }
                }
                PInvoke.CloseClipboard();
            }
       
