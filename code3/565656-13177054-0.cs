    public static class AuditLogProvider
    {
        public static AuditLog 
        {
            get { return autitLog; }
            set {
                    if (this.auditLog != null) throw new InvlaidOperationExcpetion("Audit is already configured"); 
                    this.auditLog = value; 
                }
        }
    }
