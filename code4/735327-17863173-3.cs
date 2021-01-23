    public class Audit
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string AffectedId { get; set; }       
        public string NewValue { get; set; }
    }
    
    public abstract class AuditableAction{
    	
    	public AuditableAction() {this.Audits = new List<Audit>();}
    	
    	public virtual IList<Audit> Audits { get; set; }
    	
    	public void Audit(string description){
    		this.Audits.Add(new Audit(){
    			EntityId = this.GetEntityId(),
    			AffectedId = this.Id,
    			NewValue = description
    		});
    	}
        public abstract int GetEntityId();
    }
    
    public class Action1 : AuditableAction
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public override int GetEntityId(){
            return AuditCode.Magic3.GetHashCode();
        }
    }   
    
    public class Action2 : AuditableAction
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public override int GetEntityId(){
            return AuditCode.Magic5.GetHashCode();
        }
    }
    
    public enum AuditCode{
    	Magic3 = 3,
    	Magic5 = 5
    }
