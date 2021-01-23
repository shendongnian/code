    public static class Utils
    {
    	public static IFactory MyFactory {get; private set}
        static Utils()
        {  
    		MyFactory = new Factory();
        }
    }
    //usage
    var myInterface = Utils.MyFactory.Create<IMyInterfrace>()
