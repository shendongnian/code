      List<myobj> objList = (List<myobj>)HttpContext.Current.Cache[sqlcmd.ToString()];
       if (objList == null)
         {
           List<myobj> objList = new List<myobj>();
           HttpContext.Current.Cache.Insert(sqlcmd.ToString(), objList);
    
           ....
           ....
        }
     //and  caching all  on start up
 
     protected void Application_Start()
            { 
                foreach (SqlCommandNames x in Enum.GetValues(typeof(SqlCommandNames)))
                {
                    GetObj(x);
                } 
            }
