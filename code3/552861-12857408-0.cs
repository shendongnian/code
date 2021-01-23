    if(HttpContext.Current.Session["icanDataSession"]=!null)
    {
      DataSet icanData = (DataSet)HttpContext.Current.Session["icanDataSession"];
      if (!(icanData == null))
       {
         return icanData;
       }
    }
    else 
    {
    return new Dataset();
    }
