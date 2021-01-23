    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.SqlClient;
    using System.Data;
    using System.Data.Common;
    
    namespace System.Data.SqlClient
    {
        public static class ExtensionMethods 
    
        {
            
    
    
            public static SqlParameter AddParameter(this SqlParameterCollection parms, SqlParameter param)
            {
                if (param.Value == null)
                {
                    param.Value = DBNull.Value;
                    return parms.Add(param);
                }
                else
                {
                    return parms.Add(param);        
                }
                
            }
    }
