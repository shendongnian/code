    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void searchbox_TextChanged(object sender, EventArgs e)
        {
            litActiveSearch.Text = SearchResults(searchbox.Text);        
        }
    
        private string SearchResults(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return "";
    
            var datasource = new[]
            {
                new {IdProject = 1, Title = "abcd"},
                new {IdProject = 2, Title = "aabcd"},
                new {IdProject = 3, Title = "bcde"},
                new {IdProject = 4, Title = "defgh"},
                new {IdProject = 4, Title = "defghi"}
            };
    
            string str = "";
    
            var query = from p in datasource
                        where p.Title.StartsWith(searchString)
                        select p;
    
            str += "<ul>";
    
            str += " <li class=\"ac_even ac_over\"><a href=\" ../search/search.aspx?q=" + searchString + " \" class=\"startsearch\">St<strong>a</strong>rt <strong>" +
                        "a</strong> full se<strong>a</strong>rch &gt;</a>" +
                    "</li>";
    
            str += " <li class=\"ac_odd\">" +
                        "<span class=\"category\">" +
                            "Projects<a class=\"more\" href=\" ../search/searchProjects.aspx?q=" + searchString + " \" >" + query.Count().ToString() + " results &gt;</a>" +
                        "</span>" +
                    "</li>";
            return str;
        }
    }
