    static void Main(string[] args)
    {
     Console.WriteLine("***** Simple Delegate Example *****\n");
     SimpleMath m = new SimpleMath();
     BinaryOp b = new BinaryOp(m.Add);
     b = new BinaryOp(m.Add1); // Add1 same type (signature really) as method Add
     DisplayDelegateInfo(b);
     Console.WriteLine("10 + 10 is {0}", b(10, 10));
     Console.ReadLine();
    }
