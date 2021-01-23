    public List<string> paramList 
        {
            get
            {                
                if (Session["paramList"] != null)
                {
                    return (List<string>)Session["paramList"];
                }
                else
                {
                Session["paramList"] = new List<string>();
                return (List<string>)Session["paramList"];
                }
         }                
            set { Session["paramList"] = value; }
        }
