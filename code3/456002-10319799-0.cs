         private void SaveFiles(List<string[]> files)
         {
            foreach (string[] attachment in files)
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    string path = attachment[1].ToString();
                    byte[] fileBytes = File.ReadAllBytes(path);
                    ApplicantAttachment aa1 = new ApplicantAttachment();
                    aa1.Filename = attachment[0].ToString();
                    aa1.FileType = MIMEType.GetType(attachment[1].ToString());
                    aa1.Attachment = fileBytes;
                    db.ApplicantAttachments.InsertOnSubmit(aa1);
                    db.SubmitChanges();
                }
            }
         }
