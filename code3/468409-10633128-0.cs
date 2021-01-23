    void Main()
    {
        ....
        ....
    	CastToType((ITypeContainer)myObject);
    }
    
    public void CastToType(ITypeContainer obj)
    {
    	switch (obj.ObjectType)
    	{
    		case TypeEnum.Test1:
    			var o1 = (Test1)obj;
    			break;
    		case TypeEnum.Test2:
    			var o2 = (Test2)obj;
    			break;
    	}
    }
    
    public class Test1 : ITypeContainer
    {
    	public TypeEnum ObjectType{ get; set; }  
    }
    
    public class Test2 : ITypeContainer
    {
    	public TypeEnum ObjectType{ get; set; }  
    }
    
    public enum TypeEnum
    {
    	Test1,
    	Test2,
    	Test3
    }
    
    public interface ITypeContainer
    {
    	TypeEnum ObjectType{ get; set; }  
    }
