    public string ChaveRM
    {
        get 
        { 
            if (Session["chaveRM"] != null) 
                return Session["chaveRM"].ToString();
    
            return string.Empty;
        }
        set 
        { 
            Session["chaveRM"] = value; 
        }
    }
