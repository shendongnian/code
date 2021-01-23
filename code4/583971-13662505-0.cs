    public DataTable tabela
    {
    
       get
       {
          if(HttpContext.Current.Session["tabela"] == null)
          {
               HttpContext.Current.Session["tabela"] = new DataTable ("tableName");
          }
          return HttpContext.Current.Session["tabela"] as DataTable;
       }
       set
       {
          HttpContext.Current.Session["tabela"] = value;
       }
    }
