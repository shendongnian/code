    public class MyHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            String fileName = @"c:\PathToMyFile\Myfile.jpg";
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, Convert.ToInt32(fileStream.Length));
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(buffer);
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
