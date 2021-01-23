    var multipleAttachments = new string[2, attachments.Count];
                
                int i = 0;
                attachments.ToList().ForEach(p =>
                    {
                        multipleAttachments[0, i] = p.Key;
                        multipleAttachments[1, i] = p.Value;
                        i++;
                    });
