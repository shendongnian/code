       private Attachment createAttachment(TestCaseResult testCaseResult, string resultsFile)
        {
            byte[] bytes = readFileAsByteArray(resultsFile);
            // Create attachment content;
            AttachmentContent attachmentContent = new AttachmentContent();
            attachmentContent.Content = bytes;
            attachmentContent.Workspace = this.m_targetWorkspace;
            CreateResult result = m_rallyService.create(attachmentContent);
            attachmentContent = (AttachmentContent)result.Object;
            // Create attachment.
            Attachment attachment = new Attachment();
            // Microsoft Word document.
            attachment.ContentType = "application / vnd.openxmlformats - officedocument.wordprocessingml.document";
            attachment.Content = attachmentContent;
            // Parse out file name.
            string[] parts = resultsFile.Split(new char[] { '\\' });
            attachment.Name = parts[parts.Length - 1];
            attachment.Size = bytes.Length;
            attachment.SizeSpecified = true;
            attachment.User = this.m_rallyUser;
            attachment.TestCaseResult = testCaseResult;
            attachment.Workspace = this.m_targetWorkspace;
            result = m_rallyService.create(attachment);
            attachment = (Attachment)result.Object;
            return attachment;
          }
