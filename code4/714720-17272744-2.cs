     foreach (string imageFile in files)
           {
                try
                {
                    System.Drawing.Image myImage = Image.FromFile(imageFile);
                    myImage.Tag="image name"
                    myImageList.Images.Add(myImage);
                    myImage.Dispose();
                }
                catch { }
            }
