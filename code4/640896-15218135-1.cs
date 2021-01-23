     protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                   var list = Context.Items["WebForm1List"] as List<Person>;
    
                    if (list != null)
                    {
                        foreach (Person s in list)
                        {
                            Response.Write(s.Name + "__" + s.Age);
                        }
                    }  
                }
            }
