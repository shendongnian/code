        using (ZipArchive UpdateArchive = new ZipArchive(ZipInMemory, ZipArchiveMode.Update))
        {
            ZipArchiveEntry Zipentry = UpdateArchive.CreateEntry("filename.txt");
            foreach (ZipArchiveEntry entry in UpdateArchive.Entries)
            {
                using (StreamWriter writer = new StreamWriter(entry.Open()))
                {
                    writer.WriteLine("Information about this package.");
                    writer.WriteLine("========================");
                }
            }
        }
        byte[] buffer = ZipInMemory.GetBuffer();
        Response.AppendHeader("content-disposition", "attachment; filename=Zip_" + DateTime.Now.ToString() + ".zip");
        Response.AppendHeader("content-length", buffer.Length.ToString());
        Response.ContentType = "application/x-compressed";
        Response.OutputStream.Write(buffer, 0, buffer.Length);
