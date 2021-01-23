    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Oledb
    
    namespace MembershipInformationSystem.Helpers
    {
        public class dbs
        {
            private String connectionString;
            private String OleDBProvider = "Microsoft.JET.OLEDB.4.0"; \\if ACE Microsoft.ACE.OLEDB.12.0
            private String OleDBDataSource = "C:\\yourdb.mdb";
            private String OleDBPassword = "infosys";
            private String PersistSecurityInfo = "False";
    
            public dbs()
            {
    
            }
    
            public dbs(String connectionString)
            {
                this.connectionString = connectionString;
            }
    
            public String konek()
            {
                connectionString = "Provider=" + OleDBProvider + ";Data Source=" + OleDBDataSource + ";JET OLEDB:Database Password=" + OleDBPassword + ";Persist Security Info=" + PersistSecurityInfo + "";
                return connectionString;
            }
        }
    }
