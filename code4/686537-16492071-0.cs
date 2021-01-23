    public abstract class DayInfo
    {
      protected virtual void GetInfoCore() {
        throw new NotImplementedException();
      }
      // or
      // protected abstract void GetInfoCore();
      public void GetInfo() {
        GetInfoCore();
      }
    }
    public class DayInfo<T> : DayInfo
    {
      private T info;
      public DayInfo(T data) {
        info = data;
      }
      public new T GetInfo() { // << This
        return info;
      }
      protected override void GetInfoCore() {
        GetInfo();
      }
    }
