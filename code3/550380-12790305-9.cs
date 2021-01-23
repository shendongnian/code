    [AttributeUsageAttribute(AttributeTargets.Method, 
                             Inherited = false, 
                             AllowMultiple = false)]
    public sealed class AutoActionAttribute : Attribute
    { 
      public AutoActionAttibute(int methodID)
      {
        this.MethodID = methodID;
      }
      public int MethodID { get; set; }
    }
    public class ActionProcessor
    {
      public void Process(int yourInt)
      {
        var method = this.GetType().GetMethods()
          .Where(x => x.GetCustomAttribute(typeof(AutoActionAttribute), 
                                           false) != null
                      && x.GetCustomAttribute(typeof(AutoActionAttribute), 
                                           false).MethodID == yourInt)
          .FirstOrDefault();
        if (method != null)
        {
          method.Invoke(this, null);
        }
      }
      [AutoAction(1)]
      public DoThis()
      {
      }
      [AutoAction(2)]
      public DoThat()
      {
      }
    }
