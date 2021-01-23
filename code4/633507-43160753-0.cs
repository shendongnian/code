     // Declare Delegates
        public delegate void MultiCast(int num1, int num2);
        class Program
        {
            public void Add(int num1, int num2)
            {
                Console.WriteLine(num1 + num2);
            }
            public  void Sub(int num1, int num2)
            {
                Console.WriteLine(num1 - num2);
            }
            public  void Mul(int num1, int num2)
            {
                Console.WriteLine(num1 * num2);
            }
    
            static void Main(string[] args)
            {
                MultiCast del1, del2, del3, multAddDel, multSubDel;
                del1 = new Program().Add;
                del2 = new Program().Sub;
                del3 = new Program().Mul;
    
                //Adding delegates 
                multAddDel = del1 + del2 + del3;
                multAddDel(10, 10);
                //Removing Delegates
                multSubDel = multAddDel - del3;
                multSubDel(10, 10);
    
                Console.ReadLine();
            }
        }
