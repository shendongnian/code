    using System;
    using System.Collections.Generic;
    
    namespace Test.Web
    {
        public partial class Test : System.Web.UI.Page
        {
            private readonly IList<string> database;
            private string currentSearch;
    
            public Test()
            {
                database = new List<string>();
                database.Add("hello");
                database.Add("world");
            }
    
            protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);
                uxSearchList.DataBinding += dataBindSearch;
            }
    
            protected void OnSearch(object sender, EventArgs e)
            {
                currentSearch = searchText.Text;
                uxSearchList.DataBind();
            }
    
            private void dataBindSearch(object sender, EventArgs e)
            {
                IList<string> results = new List<string>();
                foreach (string item in database)
                {
                    if (item.StartsWith(currentSearch))
                    {
                        results.Add(item);
                    }
                }
                uxSearchList.DataSource = results;
            }
        }
    }
