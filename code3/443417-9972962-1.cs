    using System; 
    using System.Threading; 
    namespace SimpleThreadExample { 
      class Counter { 
        private int count; 
        public Counter(int val) { this.count = val; } 
        public void DoCount() { 
          for(int i=0; i < count; i++) 
            System.Console.WriteLine(“Hello World”); 
        } 
        [STAThread] 
        static void Main(String[] args) { 
          Counter c = new Counter(10); 
          Thread t = new Thread(new ThreadStart(c.DoCount)); 
          t.start(); 
        } 
      } 
    }
