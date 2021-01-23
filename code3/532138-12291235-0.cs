        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString != null)
            {
                // Get username value.
                string username = Request.QueryString["username"];
                
                // Get the dynamic values and put in a list.
                List<string> dynamicTextValues = new List<string>();
                foreach (var key in Request.QueryString.Keys)
                {
                    if (key.ToString().StartsWith("e"))
                    {
                        dynamicTextValues.Add(Request.QueryString[key.ToString()]);
                    }
                }
               
                // Do what you need to do with your values.
            }
        }
