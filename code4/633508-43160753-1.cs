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
        //`There are three ways to define the multicast.`
            //1 way
      
            //Adding delegates 
            multAddDel = del1 + del2 + del3;
            multAddDel(10, 10);
            //Removing Delegates
            multSubDel = multAddDel - del3;
            multSubDel(10, 10);
            Console.WriteLine();
            Console.WriteLine("Second Way");
            //2 way
            MultiCast multAddDel1 = null;
            //Adding delegates 
            multAddDel1 += del1;
            multAddDel1 += del2;
            multAddDel1 +=  del3;
            multAddDel1(10, 10);
            //Removing Delegates
            multAddDel1 -= del3;
            multAddDel1(10, 10);
            Console.WriteLine();
            Console.WriteLine("Third Way");
            //3 way
            MultiCast multAddDel2 = null;
            //Adding delegates 
            multAddDel2 = (MultiCast)Delegate.Combine(multAddDel2, del1);
            multAddDel2 = (MultiCast)Delegate.Combine(multAddDel2, del2);
            multAddDel2 = (MultiCast)Delegate.Combine(multAddDel2, del3);
            multAddDel2(10, 10);
            //Removing Delegates
            multAddDel2 = (MultiCast)
                Delegate.Remove(multAddDel2, del3);
            multAddDel2(10, 10);
            Console.ReadLine();
        }
    }
    
