    class test1 
        {
            int x=10;
            public int getvalue() { return x; }
        }
        class test2 
        {
            string y="test";
           public  string getstring() { return y;}
            
        }
        class Program
        {
            
            static object a;
           
            static void Main(string[] args)
            {
                int n = 1;
                int x;
                string y;
                if (n == 1)
                    a = new test1();
                else
                    a = new test2();
    
                if (a is test1){
                   x = ((test1)a).getvalue();
                   Console.WriteLine(x);
                }
                if (a is test2)
                {
                    y = ((test2)a).getstring();
                    Console.WriteLine(y);
                }
            }
        }
