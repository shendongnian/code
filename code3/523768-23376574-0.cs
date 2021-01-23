    using System.Data.Objects.SqlClient ;
 
    var clientItems = from r in db.MVCInternetApplicationPkg
                          where SqlFunctions.StringConvert((double ), r.ClientAgentID)
                                == SqlFunctions.StringConvert((decimal) , getAgentID)
                          select r;
