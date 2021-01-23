    public class A
      {
        public int N;
        public string S;
        public A() {}
      }
    
      class B
      {
         void foo()
         {
            A a = new A() { N = 1, S = "string" }
         }
      }
