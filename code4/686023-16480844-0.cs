    public abstract class AuditBase
    {       
        private int? _rowVersion = 0;
        
        public virtual int? RowVersion
        {
            get { return _rowVersion; }
            set { _rowVersion = value; }
        }
    }
