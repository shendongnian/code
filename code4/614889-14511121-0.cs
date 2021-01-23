    public interface IMyInterface {
        void Function();
    }
    public static class MyInterfaceExtensions {
        public static void MyAction(this IMyInterface object)
        {
           // use object.Function() as needed
        }
    }
