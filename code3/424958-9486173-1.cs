    void Main()
    {	
    	var thisThing= new ThingEditView {UsefulID = 1, A = 2, B = 3};
    	var foo = new ThingEditView(thisThing);
    	
    	//foo.Dump();
    }
    
    // Define other methods and classes here
    public class Thing
    {
    	public int A {get; set;}
    	public int B {get; set;}		
    	public Thing() {}
    	public Thing(Thing thing)
    	{	 
    	 this.A = thing.A;
    	 this.B = thing.B;
    	}
    }
    
    public class ThingEditView : Thing
    {
    	public int UsefulID {get; set;}
    	public ThingEditView() {}
    	public ThingEditView(Thing thing) : base(thing) {
    	
    	}
    	public ThingEditView(ThingEditView view) : base(view) {
    		this.UsefulID = view.UsefulID;
    	}
    }
