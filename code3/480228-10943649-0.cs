        List<String> sitenames=null;
        using (DataReader  r = d.ExecuteReader())
        {    
           sitenames = r.AutoMap<string>().ToList();
        }
        Session["Sitealiasname"] = sitenames;
