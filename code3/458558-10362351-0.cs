    [System.Serialize]
    public class OuterClass() {
      List<InnerClass> someList = new List<InnerClass>();
    
      [System.Serialize]
      public class InnerClass() {
        public int someInt;
      }
    }
