      if (FileUpload1.HasFile)
      {
        using (ZipFile zip = ZipFile.Read(FileUpload1.FileContent))
        {
          foreach (ZipEntry entry in zip)
          {
            if (entry.IsDirectory)
              Response.Write("Directory: ");
            else
              Response.Write("File : ");
            Response.Write(entry.FileName + "<br /><br />");
          }
        }
      }
