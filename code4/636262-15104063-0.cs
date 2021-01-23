    public class Case
    {
       public int CaseId {get;set;}
       public virtual Case ExternalCase {get;set;}
    }
    
    public class ExtraField
    {
       public int ExtraFieldId {get;set;}
       public String Name {get;set;}
       public String Type {get;set;}
       public String RegexValidationString {get;set;}
       public virtual IEnumerable<ExtraFieldRef> ExtraFieldRefs {get;set;}
    }
    
    public class ExtraFieldRef
    {
       public int Id {get;set;}
       public virtual Case Case {get; set;}
       public virtual ExtraField {get;set;}
       public int Value {get;set;}
    }
