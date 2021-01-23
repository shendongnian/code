    <script runat="server">
            string xmlcontent = "";
            protected override void OnLoad(EventArgs e)
            {
                try
                {
                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    doc.Load(Server.MapPath("/usercontrols/xml/test.xml"));
                    ltrl.Text = String.Format(doc.SelectSingleNode("content").InnerText, variabletest);
                }
    
                catch (Exception ex)
                {
                    ltrl.Text = ex.Message;
                }
            }
     </script>
    <div>
        <asp:Literal runat="server" ID="ltrl" />
    </div>
