    public interface IParameter
    {
       public ParamType GetParamType();
    }
    
    public sealed class FooParameter : IParameter
    {
      public static readonly FooParameter XParameter = new FooParameter();
      public static readonly FooParameter YParameter = new FooParameter();
    
      public ParamType GetParamType() { return ParamType.Foo; }
    
      private FooParameter() { }
    }
    
    public sealed class BarParameter : IParameter
    {
      public static readonly BarParameter XParameter = new BarParameter();
      public static readonly BarParameter YParameter = new BarParameter();
    
      public ParamType GetParamType() { return ParamType.Bar; }
    
      private BarParameter() { }
    }
    
    public class MyControl : UserControl
    {
       IParameter Parameter {get; set; }
    
       ...
    }
