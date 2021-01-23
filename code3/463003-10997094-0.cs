    string filename = string.Empty;
    string path = string.Empty;
    MailMessage mailMsg = new MailMessage();
    if (AsyncUpload1.UploadedFiles.Count > 0)
                    {
                        foreach (UploadedFile file in AsyncUpload1.UploadedFiles)
                        {
                            filename = file.FileName;
                            path = System.IO.Path.GetFileName(filename);
                            string Withoutext = System.IO.Path.GetFileNameWithoutExtension(filename);
                            file.SaveAs(Server.MapPath("~/AttachMents/") + path);
                            FileStream fs = new FileStream(Server.MapPath("~/AttachMents/") + filename,
                                       FileMode.Open, FileAccess.Read);
                            System.Net.Mail.Attachment a = new System.Net.Mail.Attachment(fs, filename,
                                       MediaTypeNames.Application.Octet);
                            mailMsg.Attachments.Add(a);
                        }
                    }
