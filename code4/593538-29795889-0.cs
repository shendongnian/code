    ZipFile zip = new ZipFile();
         List<Attachment> listattachments = email.Attachments;
            int acount = attachments.Count;
            for (int i = 0; i < acount; i++)
            {
                zip.AddEntry(attachments[i].FileName, listattachments[i].Content);
            }
            Response.Clear();
            Response.BufferOutput = false;
            string zipName = String.Format("{0}.zip", message.Headers.From.DisplayName);
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
            zip.Save(Response.OutputStream);
            Response.End();     
