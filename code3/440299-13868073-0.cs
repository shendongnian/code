        public class TrackerClass : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            int ADFID = 0;
            string[] ImageNameArray = context.Request.AppRelativeCurrentExecutionFilePath.Split(new char[] { '_', '.' });
            if (int.TryParse(ImageNameArray[1], out ADFID))
            {
                **store to database***
            }
            context.Response.ContentType = "image/jpg";
            context.Response.WriteFile("images/Copyright.jpg");
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
