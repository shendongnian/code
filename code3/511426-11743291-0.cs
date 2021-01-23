    public interface IHasSize{
      int Size { get; }
    }
    public class MySize : IHasSize { 
      public int Size { get { return 4; } }
    }
    public class RequiresASize<TSize> where TSize : IHasSize, new()
    {
      private int _size = new TSize().Size;
    }
    public class ProvidesASize : RequiresASize<MySize>{
      //_size in base class will be 4
    }
