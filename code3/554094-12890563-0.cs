    public abstract class Organization : IKeyed<int> { 
        public virtual int Id { get; protected set; } 
        public virtual string Code { get; set; }
        // remove this property
        // public virtual OrganizationType orgType {get;set;} 
        public virtual Organization Parent {get;set;} 
        public virtual IList<Organization> Children {get;set;} 
 
        // move this property to sub-class
        // public virtual typeA {get; set;} // only meaningful when organization type is 'Head office' 
        // move this property to sub-class
        // public virtual typeB {get;set;}// only meaningful when 'Region'
        public virtual void AddChild(Organization org){...} 
        ... 
 
    }
    public class HeadOffice : Organization
    {
        public virtual typeA { get; set; }
    }
    
    public class Region : Organization
    {
        public virtual typeB { get; set;}
    }
    
    public class OtherOrganizationType : Organization
    {
        // 
    }
