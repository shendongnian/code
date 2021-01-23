        void DownloadFile(string filename)
        {
                //string filename = "c:\\temp\\test.csv";
                byte[] contents = System.IO.File.ReadAllBytes(filename);
                Response.Clear();
                Response.ClearHeaders();
  
                Response.AppendHeader("Content-disposition", String.Format("attachment; filename=\"{0}\"", System.IO.Path.GetFileName(filename)));
                Response.AppendHeader("Content-Type", "binary/octet-stream");
                Response.AppendHeader("Content-length", contents.Length.ToString());
                Response.BinaryWrite(contents);
                if (Response.IsClientConnected)                
                    Response.Flush();
        }
