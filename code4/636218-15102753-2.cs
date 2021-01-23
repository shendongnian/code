    public void DoStuff()
      {
        Console.WriteLine(typeof(A).IsInstanceOfType(this));
        Console.WriteLine(this.GetType());
        C.DoStuff(this); 
      }
