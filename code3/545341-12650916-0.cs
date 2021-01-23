    public class MyBase {
      public List<SomeObject> list;
      public MyBase(){
        list = new List<SomeObject>();
        list.Add(new SomeObject());
        list.Add(new SomeObject());
        list.Add(new SomeObject());
      }
      ~MyBase() {
        foreach (SomeObject obj in list) {
          obj.Cleanup();
        }
        list.Clear();
      }
    }
