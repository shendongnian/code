    public class SQLBaseDialect : GenericDialect
    {
        public override string ForUpdateString
        {
            get { return " "; }
        }
        public override bool ForUpdateOfColumns
        {
            get { return true; }
        }
        public override string GetForUpdateString(string aliases)
        {
            return " for update of " + aliases;
        }
        public override bool SupportsOuterJoinForUpdate
        {
            get { return false; }
        }
        public override bool SupportsParametersInInsertSelect
        {
            get { return false; }
        }
    }
