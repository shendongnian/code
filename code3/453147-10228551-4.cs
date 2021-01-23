    public class AuditLogEntry
    {
            private ObjectBase<AuditLogEntry.AuditLogEntryStruct> _entry;
            private struct AuditLogEntryStruct
            {
                public int AuditID;
            }
    }
    
    public abstract class ObjectBase<T> 
    {
    }
