     if (RelatedFiles.Any())
                {
                    foreach (var file in RelatedFiles)
                    {
                        if (file != null) // here is just check for a null value.
                        {
                            byte[] uploadedFile = new byte[file.InputStream.Length];
                            file.InputStream.Read(uploadedFile, 0, file.ContentLength);
                            FileInfo fi = new FileInfo(file.FileName);
                            var upload = new UploadedFile
                            {
                                ContentType = file.ContentType,
                                Content = uploadedFile,
                                FileName = fi.Name,
                                ContentExtension = fi.Extension,
                            };
                            newIssuePaper.RelatedDocuments.Add(upload);
                        }
                    }
