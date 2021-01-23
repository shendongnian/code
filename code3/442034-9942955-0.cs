    public class AddNoLockHintsInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            // Modify the sql to add hints
            return sql;
        }
    }
