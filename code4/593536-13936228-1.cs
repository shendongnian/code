    public ActionResult DownloadZip()
    {
        using (MemoryStream ms = new MemoryStream())
        {
          using (ZipFile zip = new ZipFile())
          {
             zip.AddFile("ReadMe.txt");
             zip.AddFile("7440-N49th.png");
             zip.AddFile("2008_Annual_Report.pdf");        
             zip.Save(ms); // this will save the files in memory steam
          }
          byte[] fileData = ms.GetBuffer();// I think this will work. Last time I did it, I did something like this instead... Zip.CreateZip("LogPosts.csv", System.Text.Encoding.UTF8.GetBytes(csv));
          var cd = new System.Net.Mime.ContentDisposition
          {
              FileName = "Whatever.zip",
              // always prompt the user for downloading, set to true if you want 
              // the browser to try to show the file inline
              Inline = false,
          };
          Response.AppendHeader("Content-Disposition", cd.ToString());
          return File(fileData, "application/octet-stream");
          }
      }
