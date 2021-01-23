    if(Request.QueryString["sincemodified"] != null)
    {
       DateTime dt;
       if(DateTime.TryParse(Request.QueryString["sincemodified"], out dt)
         {
          //valid date
         }
    }
