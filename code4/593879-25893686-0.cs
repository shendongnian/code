    using (FileStream fs = new FileStream(f.GetServerPathOfFile(imagePath), FileMode.Open))
                    {
                        byte[] bytes = new byte[fs.Length];
                        fs.Write(bytes, 0, (int)fs.Length);
                        pictureIdx = templateWorkbook.AddPicture(bytes, PictureType.JPEG);
