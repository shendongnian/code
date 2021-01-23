    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Script.Serialization;
    public partial class _Default : System.Web.UI.Page
    {
        protected string[] pinLat;
        protected string[] pinLong;
    
        public static class JavaScript
        {
            public static string Serialize(object o)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(o);
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            // Populate your latiude and longitude from SQL Server into our arrays to be used in javascript
            pinLat = new string[3] { "55.342575", "15.342575", "25.342575" };
            pinLong = new string[3] { "-55.342570", "-55.342570", "-55.342570" };
        }
    }
