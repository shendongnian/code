     string filePath = ConfigurationManager.AppSettings.Get("ImageUploadPath");
    
                              if (!Directory.Exists(filePath))
                              {
                                  Directory.CreateDirectory(filePath);
                              }
    
                              filePath = filePath + "\\" + picture.FileName + "." + picture.FileType;
    
                              if (picture.FileName != string.Empty)
                              {
                                  fileStream = File.Open(filePath, FileMode.Create);
                                  writer = new BinaryWriter(fileStream);
                                  writer.Write(picture.FileStream);
                              }
