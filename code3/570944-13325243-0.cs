    // In webform code behind: 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Collections.Specialized;
    
    namespace testURL
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
    
                queryString["firstKey"] = "a";
                queryString["SecondKey"] = "b";
    
                string url=GenerateURL(queryString); // call function to get the url
            }
    
            private string GenerateURL(NameValueCollection nvc)
            {
                return "index.aspx?" + string.Join("&", Array.ConvertAll(nvc.AllKeys, key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(nvc[key]))));
            }
    
        }
    }
    
        
        // To get information to generate URL in MVC please check the following tutorial:
        http://net.tutsplus.com/tutorials/generating-traditional-urls-with-asp-net-mvc3/
