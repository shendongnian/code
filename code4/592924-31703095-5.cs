                FileUploadDBModel fileUploadModel = new FileUploadDBModel();
                //uploading multiple files in the database
                foreach (var item in model.File)
                {
                    byte[] uploadFile = new byte[item.InputStream.Length];
                    item.InputStream.Read(uploadFile, 0, uploadFile.Length);
                    fileUploadModel.FileName = item.FileName;
                    fileUploadModel.File = uploadFile;
                    db.FileUploadDBModels.Add(fileUploadModel);
                    db.SaveChanges();
                }
            }
 
 
