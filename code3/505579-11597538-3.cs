    <%@ Page Language="C#" AutoEventWireup="true" %>
    
    <script language="c#" runat="server">
        public void Page_Load(object sender, EventArgs e)
        {
            string url = "https://............10000.JPG";
            byte[] imageData;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                imageData = client.DownloadData(url);
            }
    
            Response.ContentType = "image/png";  // Change the content type if necessary
            Response.OutputStream.Write(imageData, 0, imageData.Length);
            Response.Flush();
            Response.End();
        }
    </script>
