    public List<int> Indices
    {
        get
        {
            var val = Session["indicesList"] as List<int>;
            if(val == null) 
            {
                val = new List<int>();
                Session["indicesList"] = val;
            }
            return val;
        }
        set
        {
            Session["indicesList"] = value;
        }
    }
