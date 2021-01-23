    public class Alice {
      public event Action<object> ValueChanged;
      protected void RaiseValueChanged(object o) {
        if (ValueChanged != null) {
          ValueChanged(o);
        }
      }
    }
