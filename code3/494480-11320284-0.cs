    using System;
    using System.Net;
    using System.Text;
    using System.IO;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
    
            byte[] buf = new byte[8192];
            
            //do get request
            HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create("http://sms-om.com/smspro/sendsms.php?user=HatemSalem");
    
    
            HttpWebResponse response = (HttpWebResponse)
                request.GetResponse();
    
    
            Stream resStream = response.GetResponseStream();
    
            string tempString = null;
            int count = 0;
            //read the data and print it
            do
            {
                count = resStream.Read(buf, 0, buf.Length);
                if (count != 0)
                {
                    tempString = Encoding.ASCII.GetString(buf, 0, count);
    
                    sb.Append(tempString);
                }
            }
            while (count > 0);
            Response.Write(sb.ToString());
        }
    }
