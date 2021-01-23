    public interface IInitializeWithInt
    {
         void Initialize(int i);
    }
    public TestClass : IInitializeWithInt
    {
         private int _i;
         public void Initialize(int i)
         {
             _i = i;
         }
         ...
    }
