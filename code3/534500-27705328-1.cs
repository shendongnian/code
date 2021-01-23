                    if (Attachmentlistbox.Items.Count != 0)
                    {
                        for (int i = 0; i < Attachmentlistbox.Items.Count; i++)
                            mailMessage.Attachments.Add(new Attachment(Attachmentlistbox.Items[i].ToString()));
                    }
