    public class UploadController : Controller
    {
        private string videoAddress = "~/App_Data/Videos";
        [HttpPost]
        public string MultiUpload(string id, string fileName)
        {
            var chunkNumber = id;
            var chunks = Request.InputStream;
            string path = Server.MapPath(videoAddress+"/Temp");
            string newpath = Path.Combine(path, fileName+chunkNumber);
            using (FileStream fs = System.IO.File.Create(newpath))
            {
                byte[] bytes = new byte[3757000];
                int bytesRead;
                while ((bytesRead=Request.InputStream.Read(bytes,0,bytes.Length))>0)
                {
                    fs.Write(bytes,0,bytesRead);
                }
            }
            return "done";
        }
        [HttpPost]
        public string UploadComplete(string fileName, string complete)
        {
            string tempPath = Server.MapPath(videoAddress + "/Temp");
            string videoPath = Server.MapPath(videoAddress);
            string newPath = Path.Combine(tempPath, fileName);
            if (complete=="1")
            {
                string[] filePaths = Directory.GetFiles(tempPath).Where(p=>p.Contains(fileName)).OrderBy(p => Int32.Parse(p.Replace(fileName, "$").Split('$')[1])).ToArray();
                foreach (string filePath in filePaths)
                {
                    MergeFiles(newPath, filePath);
                }
            }
            System.IO.File.Move(Path.Combine(tempPath, fileName),Path.Combine(videoPath,fileName));
            return "success";
        }
        private static void MergeFiles(string file1, string file2)
        {
            FileStream fs1 = null;
            FileStream fs2 = null;
            try
            {
                fs1 = System.IO.File.Open(file1, FileMode.Append);
                fs2 = System.IO.File.Open(file2, FileMode.Open);
                byte[] fs2Content = new byte[fs2.Length];
                fs2.Read(fs2Content, 0, (int) fs2.Length);
                fs1.Write(fs2Content, 0, (int) fs2.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
            }
            finally
            {
                if (fs1 != null) fs1.Close();
                if (fs2 != null) fs2.Close();
                System.IO.File.Delete(file2);
            }
        }
    }
