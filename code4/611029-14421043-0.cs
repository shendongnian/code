    public class FinalQuery
    {
        protected string _table;
        protected string[] _selectFields;
        protected string _where;
        protected string[] _groupBy;
        protected string _having;
        protected string[] _orderByDescending;
        protected string[] _orderBy;
        protected FinalQuery()
        {
        }
        public override string ToString()
        {
            var sb = new StringBuilder("SELECT ");
            AppendFields(sb, _selectFields);
            sb.AppendLine();
            sb.Append("FROM ");
            sb.Append("[").Append(_table).AppendLine("]");
            if (_where != null) {
                sb.Append("WHERE").AppendLine(_where);
            }
            if (_groupBy != null) {
                sb.Append("GROUP BY ");
                AppendFields(sb, _groupBy);
                sb.AppendLine();
            }
            if (_having != null) {
                sb.Append("HAVING").AppendLine(_having);
            }
            if (_orderBy != null) {
                sb.Append("ORDER BY ");
                AppendFields(sb, _orderBy);
                sb.AppendLine();
            } else if (_orderByDescending != null) {
                sb.Append("ORDER BY ");
                AppendFields(sb, _orderByDescending);
                sb.Append(" DESC").AppendLine();
            }
            return sb.ToString();
        }
        private static void AppendFields(StringBuilder sb, string[] fields)
        {
            foreach (string field in fields) {
                sb.Append(field).Append(", ");
            }
            sb.Length -= 2;
        }
    }
    public class GroupedQuery : FinalQuery
    {
        protected GroupedQuery()
        {
        }
        public GroupedQuery Having(string condition)
        {
            if (_groupBy == null) {
                throw new InvalidOperationException("HAVING clause without GROUP BY clause");
            }
            if (_having == null) {
                _having = " (" + condition + ")";
            } else {
                _having += " AND (" + condition + ")";
            }
            return this;
        }
        public FinalQuery OrderBy(params string[] fields)
        {
            _orderBy = fields;
            return this;
        }
        public FinalQuery OrderByDescending(params string[] fields)
        {
            _orderByDescending = fields;
            return this;
        }
    }
    public class Query : GroupedQuery
    {
        public Query(string table, params string[] selectFields)
        {
            _table = table;
            _selectFields = selectFields;
        }
        public Query Where(string condition)
        {
            if (_where == null) {
                _where = " (" + condition + ")";
            } else {
                _where += " AND (" + condition + ")";
            }
            return this;
        }
        public GroupedQuery GroupBy(params string[] fields)
        {
            _groupBy = fields;
            return this;
        }
    }
