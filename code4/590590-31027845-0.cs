    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Newtonsoft.Json;
    using System.Net;
    
    namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            WebClient client = new WebClient();
            string jsonstring;
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                jsonstring = client.DownloadString("http://maps.googleapis.com/maps/api/geocode/json?address="+txtzip.Text.Trim());
                dynamic dynObj = JsonConvert.DeserializeObject(jsonstring);
    
                Response.Write(dynObj.results[0].address_components[1].long_name);
            }
        }
    }
