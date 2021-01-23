    TimeSpan ts;
    if(null != Request.QueryString["period"])
    {
      DateTime dt1 = Convert.ToDateTime(Request.QueryString["period"].ToString());
      DateTime dt2 = DateTime.Now;
      TimeSpan ts = dt2 - dt1;
    }
            
