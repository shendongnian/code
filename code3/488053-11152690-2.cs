    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var page = (Page.PreviousPage as _Default);
            if (page != null)
            {
                var xml = new XDocument(
                    new XElement(
                        "user",
                        new XElement("firstName", page.FirstName),
                        new XElement("lastName", page.LastName)
                    )    
                );
                var file = Server.MapPath("~/test.xml");
                xml.Save(file);
            }
        }
    }
