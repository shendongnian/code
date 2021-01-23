     public class ConnectDB
     {
        public static OleDbConnection getConStr() {
            return OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="  +   HttpContext.Current.Server.MapPath("Users.accdb") + ";Persist Security Info=False");       
        }
    }
