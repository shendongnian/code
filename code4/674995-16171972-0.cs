    public abstract class MsgType
    {
      public bool IsForwardable { get; }
    }
    
    public class A : MsgType
    {
      public override bool IsForwardable
      {
        get { return true; }
      }
    }
    
    public class F : MsgType
    {
      public override bool IsForwardable
      {
        get { return false; }
      }
    }
