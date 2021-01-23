    public class SchemaSqlInterceptor : EmptyInterceptor, IInterceptor
    {
        public string MASTER_USER { get; set; }
        public string TRAN_USER { get; set; }
        NHibernate.SqlCommand.SqlString IInterceptor.OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            return sql.Replace("{MASTER_USER}", MASTER_USER).Replace("{TRAN_USER}", TRAN_USER);
        }
    }
