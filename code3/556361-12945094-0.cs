    public partial class api: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getXML();
        }
    
    
        public void getXML()
        {
    
            WebRequest req = WebRequest.Create("http://webdev.clic.det.nsw.edu.au/Mum12/Public/Sample.xml");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            req.ContentType = "text/xml charset=utf8";
    
            Stream streamdata = resp.GetResponseStream();
            StreamReader reader = new StreamReader(streamdata);
    
            string serverresponse = reader.ReadToEnd();
    
            reader.Close();
            streamdata.Close();
            resp.Close();
    
            Response.Write(serverresponse);
        }
    }
