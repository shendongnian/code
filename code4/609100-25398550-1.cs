    namespace System.Data.Entity {
        public static partial class DatabaseExtensions {
            public static T SqlScalarResult<T>(this Database db, string function, System.Data.SqlClient.SqlParameter[] parameters) {
                List<string> functionArgs = new List<string>();
                foreach (System.Data.SqlClient.SqlParameter parameter in parameters) {
                    functionArgs.Add("@" + parameter.ParameterName);
                }
                string sql = string.Format("SELECT dbo.{0}({1});", function, string.Join(",", functionArgs));
                return (T)db.SqlQuery<T>(sql, parameters).FirstOrDefault();
            }
        }
    }
