    public static class DatabaseExtensions {
        public static IEnumerable<TResult> ExecuteStoredProcedure<TResult>(
                 this Database database, 
                 IStoredProcedure<TResult> procedure, 
                 string spName) {
            var parameters = CreateSqlParametersFromProperties(procedure);
            var format = CreateSPCommand<TResult>(parameters, spName);
            return database.SqlQuery<TResult>(format, parameters.Cast<object>().ToArray());
        }
        private static List<SqlParameter> CreateSqlParametersFromProperties<TResult>
                 (IStoredProcedure<TResult> procedure) {
            var procedureType = procedure.GetType();
            var propertiesOfProcedure = procedureType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var parameters =
                propertiesOfProcedure.Select(propertyInfo => new SqlParameter(
                        string.Format("@{0}", 
                        (object) propertyInfo.Name), 
                        propertyInfo.GetValue(procedure, new object[] {})))
                    .ToList();
            return parameters;
        }
        private static string CreateSPCommand<TResult>(List<SqlParameter> parameters, string spName)
        {
            var name = typeof(TResult).Name;
            string queryString = string.Format("{0}", spName);
            parameters.ForEach(x => queryString = string.Format("{0} {1},", queryString, x.ParameterName));
            return queryString.TrimEnd(',');
        }
        public interface IStoredProcedure<TResult> {
        }
    }
