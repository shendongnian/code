    class TypeX { }
    
    class TypeY : TypeX { }
    
    class Base
    {
    	public virtual TypeX Prop { get; set; }
    }
    
    class Derived : Base
    {
    	public override TypeY Prop { get; set; }
    }
    
    Derived derived = new Derived();
    derived.Prop = new TypeY(); // Valid
    
    Base @base = derived;
    @base.Prop = new TypeX(); // Invalid - As this would be using the derived property which should be of TypeY
