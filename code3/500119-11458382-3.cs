            using (var mem = new MemoryStream(file.InputStream)
            {
                _documentStore.DatabaseCommands.PutAttachment("upload/" + YourUID, null, mem,
                                                              new RavenJObject
                                                                  {
                                                                      { "OtherData", "Can Go here" }, 
                                                                      { "MoreData", "Here" }
                                                                  });
            }
