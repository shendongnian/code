    public partial class UserDefinedFunctions
    {
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString SqlFunction1()
        {
            // Put your code here
            return new SqlString (string.Empty);
        }
    }
