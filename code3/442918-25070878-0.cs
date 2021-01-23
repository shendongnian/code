    public class OptionInterceptor: EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            var parameters = sql.GetParameters();
            var paramCount = parameters.Count();
            if (paramCount > 0)
                return sql;
            string optionString = " OPTION (OPTIMIZE FOR (";
            for (var i = 0; i < paramCount; i++)
            {
                var comma = i > 0 ? "," : string.Empty;
                optionString = optionString + comma + "@p" + i + " UNKNOWN";
            }
            
            optionString = optionString + "))";
            var builder = new SqlStringBuilder(sql);
            builder.Add(optionString);
            return builder.ToSqlString();
        }
    }
