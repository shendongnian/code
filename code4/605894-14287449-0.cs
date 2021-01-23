    public void MyUsage(ITypesafeEnum myEnum)
    {
    	Console.WriteLine(myEnum.Name);
    	Console.WriteLine(myEnum.Val);
    }
    
    public interface ITypesafeEnum{
    	string Name{get;}
    	int Val {get;}
    }
    
    public  class TypesafeEnum:ITypesafeEnum{
    
    	public string Name {get;private set;}
    	public int Val {get;private set;}
    	private TypesafeEnum(){}
    	private TypesafeEnum(string name, int val){
    		Name = name;
    		Val = val;
    	}
    
    	public static readonly TypesafeEnum Bedroom = new TypesafeEnum("Bedroom", 1);
    	public static readonly TypesafeEnum LivingRoom = new TypesafeEnum("Living Room",2);
    }
