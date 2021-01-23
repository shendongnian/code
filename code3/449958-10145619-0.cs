        protected string Name
        {
            get
            {
                if (Session["Name"] == null)
                {
                    var results = GoLoadFields();                    
                    return Session["Name"].ToString();
                }
                return Session["Name"].ToString();
            }
            set
            {
                Session["Name"] = value;
            }
        }
