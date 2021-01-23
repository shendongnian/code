    public MyDBEntities ctx
    {
        get
        {
            string ocKey = "ctx_" + HttpContext.Current.GetHashCode().ToString("x");
            if (!HttpContext.Current.Items.Contains(ocKey))
                HttpContext.Current.Items.Add(ocKey, new MyDBEntities ());
            return HttpContext.Current.Items[ocKey] as MyDBEntities ;
        }
    }  
