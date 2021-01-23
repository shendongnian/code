    public class MyStreamHandler : IHttpHandler {
    public void ProcessRequest (HttpContext context) {
        MyServiceClient tcpClient = new MyServiceClient();
        Image img = Image.FromStream(tcpClient.GetMyStream(30,100));
        img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg)  
            img.Dispose()
        }
        public bool IsReusable {
    	get {
    	    return false;
    	}
       }
    }
