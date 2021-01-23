     if (dlgOpen.ShowDialog() ?? false)
                        {
                            byte[] bytes = System.IO.File.ReadAllBytes(dlgOpen.FileName);
                                                                                                                   
                                fd.FileId = Guid.NewGuid();
                                fd.DataFile = bytes;
                                fd.Title = dlgOpen.FileName;                   
                                context.FileDatas.InsertOnSubmit(fd);
                                context.SubmitChanges();
  
