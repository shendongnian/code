        if (Session["CountCounter"] == null)
        {
            sessionCount = 0;
            Session["CountCounter"]=sessionCount;
        }
        else
        {
            sessionCount = Convert.ToInt32(Session["CountCounter"]);
            sessionCount++;
            Session["CountCounter"]=sessionCount;
         }
    
