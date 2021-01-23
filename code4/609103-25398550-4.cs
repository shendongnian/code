        /// <summary>
        /// Calls a given Sql function and returns a singular value
        /// </summary>
        /// <param name="db">Current DbContext instance</param>
        /// <typeparam name="T">CLR Type</typeparam>
        /// <param name="sql">Sql function</param>
        /// <param name="parameters">Sql function parameters</param>
        /// <param name="schema">Owning schema</param>
        /// <returns>Value of T</returns>
        public T SqlScalarResult<T>(DbContext db, 
                                    string sql, 
                                    SqlParameter[] parameters,
                                    string schema = "dbo") {
            if (string.IsNullOrEmpty(sql)) {
                throw new ArgumentException("function");
            }
            if (parameters == null || parameters.Length == 0) {
                throw new ArgumentException("parameters");
            }
            if (string.IsNullOrEmpty(schema)) {
                throw new ArgumentException("schema");
            }
            string cmdText =
                $@"SELECT {schema}.{sql}({string.Join(",",
                    parameters.Select(p => "@" + p.ParameterName).ToList())});";
            // ReSharper disable once CoVariantArrayConversion
            return db.Database.SqlQuery<T>(cmdText, parameters).FirstOrDefault();
        }
    }
