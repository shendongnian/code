    public class CustomException : Exception
    {
      public override string Message 
      { 
        get 
        {
          if (this.CustomThing == null) 
          {
            return base.Message;
          }
          else
          {
            return string.Format("Custom thing: {0}", this.CustomThing);
          }
        }
      }
    }
