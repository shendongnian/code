     foreach (string imageFile in files)
           {
                try
                {
                    System.Drawing.Image myImage = Image.FromFile(imageFile);
                    myImage.Tag="image name for each item";//you can put for example image file name
                    myImageList.Images.Add(myImage);
                    myImage.Dispose();
                }
                catch { }
            }
