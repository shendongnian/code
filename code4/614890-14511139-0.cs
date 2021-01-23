    public interface IMyInterface
    {
       void Function();
    }
    
    public static class MyInterfaceExtensions
    {
        public static void MyAction(this IMyInterface obj)
        {
        	obj.Function();
        }
    }
