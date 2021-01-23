    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
      {
            var strURL = "http://www.google.com";
    
            System.Net.WebResponse objResponse = default(System.Net.WebResponse);
            System.Net.WebRequest objRequest = default(System.Net.WebRequest);
            string result = null;
            objRequest = System.Net.HttpWebRequest.Create(strURL);
            objResponse = objRequest.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(objResponse.GetResponseStream());
            result = sr.ReadToEnd();
            //clean up StreamReader 
            sr.Close();
    
            //WRITE OUTPUT
            Response.ContentType = "application/html";//remove context.
            Response.Write(result);//""
            Response.Flush();//""
    
        }
    </script>
