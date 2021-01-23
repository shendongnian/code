    using System;
    using System.Collections.Generic;
    //using System.Linq;
    //using System.Web;
    using System.Data.SqlClient;
    using System.Configuration;
    
    
        namespace ANTrack
        {
            public class MyObjDataSource
            {
                public int iCount;
                public string strName;
    
                public void GetIncident(int IncidentID)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                }
            }
        }
