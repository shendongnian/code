        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Form != null)
            {
                // Get username value.
                string username = Request.Form["username"];
                
                // Get the dynamic values and put in a list.
                List<string> dynamicTextValues = new List<string>();
                foreach (var key in Request.Form.Keys)
                {
                    if (key.ToString().StartsWith("e"))
                    {
                        dynamicTextValues.Add(Request.Form[key.ToString()]);
                    }
                }
               
                // Do what you need to do with your values.
            }
        }
