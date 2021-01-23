    void Main()
    {
    	//IMold mold = new IMold(); // error - can't create instance of an interface
    	//Fruit fruit = new Fruit(); // error - can't create instance of an abstract class
    	
    	Apple apple1 = new Apple(); // good
    	Orange orange1 = new Orange(); // good
    	
    	Fruit apple2 = (Fruit)apple1; // good - Apples are fruit
    	Fruit orange2 = (Fruit)orange1; // good - oranges are fruit
    	
    	IFruitMold apple3 = (IFruitMold)apple2; // good - Apples fit the Mold
    	IFruitMold orange3 = (IFruitMold)orange2; // good - Oranges also fit the mold
    	
    		
    	//now I can do this:
        //Notice that `fruits` is of type IList<T> but the new is List<T>
        //This is the exact concept we are talking about
        //IList<T> is some kind of set of items that can be added or subtracted from
        //but we don't have to care about the implementation details of *HOW* this is done
    	IList<IFruitMold> fruits = new List<IFruitMold>();
        fruits.add(apple3);
        fruits.add(orange3);
    	foreach( var fruit in fruits )
    	{
    		fruit.PlasticColor.Dump(); // ok I can read
    		fruit.PlasticColor = ""; // error - no Set defined in the interface
    		
    		// depending on the **implementation details** of what type of fruit this is true or false
    		// we don't care in the slightest, we just care that we have some IFruitMold instances
    		fruit.RequiresPainting.Dump(); 
    	}
    }
    
    interface IFruitMold
    {
    	string PlasticColor { get; }
    	bool RequiresPainting { get; }
    }
    
    abstract class Fruit : IFruitMold
    {
    	private string m_PlasticColor = string.Empty;
    	public string PlasticColor { get; private set; }
    	public abstract bool RequiresPainting { get; }
    }
    
    //notice that we only define the abstract portion of the base class
    //it defined PlasticColor for us already!
    //the keyword `override` is required  - it is to make it clear that 
    //this member is overriding a member from it's parent.
    class Apple : Fruit
    {
    	public override bool RequiresPainting { get { return true; } }
    }
    
    class Orange : Fruit
    {
    	public override bool RequiresPainting { get { return false; } }
    }
