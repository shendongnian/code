    public class MyDerived : MyBase {
      public MyDerived() {
        foreach (SomeObject obj in list) {
          obj.SomeProperty = new Handler();
        }
      }
      ~MyDerived(){
        foreach (SomeObject obj in list) {
          obj.SomeProperty.Cleanup();
        }
      }
    }
