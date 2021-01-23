     if (myfile.Exists)
     {
         //Clear the content of the response    
          try
          {
              Response.ClearContent();
             // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header    
             Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);
             // Add the file size into the response header    
             Response.AddHeader("Content-Length", myfile.Length.ToString());    // Set the ContentType    
             Response.ContentType = ReturnMimeType(myfile.Extension.ToLower());    // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)    
             Response.TransmitFile(myfile.FullName);
             Response.Flush();
             Response.Close();
             Response.End();
            }
            finally
            {
                File.Delete(myfile.FullName);
            }
      }
