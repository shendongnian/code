    foreach (Images item in ListOfImages)
                    {
                        newPath = Path.Combine(newPath, item.ImageName + item.ImageExtension);
                        FileStream f = File.Create(newPath);
                        f.Write(item.File, 0, item.File.Length);
                    }
