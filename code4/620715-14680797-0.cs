    public partial class MyDataModel
    {
        partial void OnContextCreated()
        {
            this.SavingChanges += new EventHandler(CreateAuditLog);
        }
        void CreateAuditLog(object sender, EventArgs e)
        {
             var changes = this.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted | EntityState.Modified);
            if (!changes.Any())
                return;
            var auditDataList = new List<AuditLogEntry>();
            foreach (ObjectStateEntry stateEntryEntity in changes)
            {
                if (!stateEntryEntity.IsRelationship && stateEntryEntity.Entity != null && !(stateEntryEntity.Entity is AuditLogEntry))
                {
                    var audit = new AuditLogEntry();
                    auditDataList.Add(audit);
                }
            }
            if (auditDataList.Count > 0)
            {
                foreach (var audit in auditDataList)
                    this.AddToAuditLogEntries(audit);
            }      
         }  
    }
