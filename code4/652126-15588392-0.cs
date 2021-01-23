    public class SQLBaseDriver : NHibernate.Driver.ReflectionBasedDriver
    {
        public SQLBaseDriver()
            : base("Gupta.SQLBase.Data",
                   "Gupta.SQLBase.Data.SQLBaseConnection",
                   "Gupta.SQLBase.Data.SQLBaseCommand")
        {
            
        }
        public override bool UseNamedPrefixInSql
        {
            get { return true; }
        }
        public override bool UseNamedPrefixInParameter
        {
            get { return false; }
        }
        public override string NamedPrefix
        {
            get { return ":"; }
        }
    }
