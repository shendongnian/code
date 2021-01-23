    if (newEmail.Attachments.Count > 0)
    {
          for (int i = 1; i <= newEmail.Attachments.Count; i++)
          {
               newEmail.Attachments[i].SaveAsFile
                    (@"C:\TestFileSave\" +
                    newEmail.Attachments[i].FileName);
          }
    }
