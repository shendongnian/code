    class Program
    {
      static unsafe void Main()
      {
        char A = 'A';
        char B = 'B';
        var O = new char*[] { &A, &B };
            
        *O[0] = 'C';
        System.Console.WriteLine(A + "," + B); // outputs C,B            
      }
    }
