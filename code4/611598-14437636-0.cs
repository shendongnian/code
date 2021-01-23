    public class BaseControl
    {
      public object Click(){ }
      public object GetText() { }
      public virtual object ExecuteCommand() { }
    }
    public class TableControl : BaseControl
    {
      public override object ExecuteCommand()
      {
        //Do your method
        return base.GetText();
      }
    }
