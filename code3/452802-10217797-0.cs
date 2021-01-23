    public interface IAuditMessageProvider {
        public String MakeMeAnAuditMessage(/* some args perhaps */);
    }
    
    public class PiAuditMessageProvider : IAuditMessageProvider {
        public String MakeMeAnAuditMessage() { return "3.14"; }
    }
    
    [Audit(typeof(PiAuditMessageProvider))]
    public void myMethod { ... }
