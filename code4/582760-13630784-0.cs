    using System;
    
    namespace myProject
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var o=new customObject
                    {
                        prop1 = "Value1", 
                        prop2 = "Value2", 
                        prop3 = "Value3"
                    };
                var x = new System.Xml.Serialization.XmlSerializer(o.GetType());
                Response.ContentType = "text/xml";
                x.Serialize(Response.Output, o);
            }
        }
    
        public class customObject
        {
            public string prop1;
            public string prop2;
            public string prop3;
        }
    }
