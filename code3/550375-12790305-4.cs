    public class ActionProcessor
    {
      public void Process(int yourInt)
      {
        var methods = this.GetType().GetMethods();
        if (methods.Length > yourInt)
        {
          methods[yourInt].Invoke(this, null);
        }
      }
      public DoThis()
      {
      }
      public DoThat()
      {
      }
