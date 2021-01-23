    public class MyObject
    {
        private int num;
    
        public int Num
        {
            get
            {
               return (this.num);
            }
            set
            {
               this.num = value;
            }
        }
    
        public MyObject(int num)
        {
            this.Num = num;
        }    
    }
    public class Program
    {
        public static MyObject DoWork(int num)
        {
            return new MyObject(num);
        }
    
        [STAThread]
        public static int Main(string[] args)
        {
            DoWork(5);
    
            return 0;
        }
    }
