    namespace DataAccess
    {
        public class clsConnection
        {
            public SqlConnection OpenCon()
            {           
                    DBN = "PMS";
                    SERVER = "server-PC\\SQLEXPRESS";
                    USER = "SA";
                    PWD = "Sysadmin123";
        
                    SqlConnection cn = new SqlConnection("Initial Catalog=" + DBN + ";Data Source=" + SERVER + "; User id =" + USER + "; Password =" + PWD + ";CONNECT Timeout=10");
                    .....
                    cn.Open();                   
                    return cn;
                
            }        
        
        }
    }
