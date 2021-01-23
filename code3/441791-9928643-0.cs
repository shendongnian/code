    struct S
    {
      private readonly int x;
      public S(int x) { this.x = x; }
      public void Badness(ref S s)
      {
        Console.WriteLine(this.x);   
        s = new S(this.x + 1);
        // This should be the same, right?
        Console.WriteLine(this.x);   
      }
    }
