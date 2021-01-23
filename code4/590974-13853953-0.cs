    foreach (OpenPop.Mime.MessagePart attachment in attachments)
                            {
                                if (attachment != null)
                                {
                                    string ext = attachment.FileName.Split('.')[1];
    
                                    Filename = DateTime.Now.Ticks.ToString();
                                    FileInfo file = new FileInfo((AppDomain.CurrentDomain.BaseDirectory + "Downloaded//") + Filename + ".csv" );
    
                                    // Check if the file already exists
                                    if (!file.Exists)
                                    {
                                        attachment.Save(file);
                                    }
    
                                }
                      }
