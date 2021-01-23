    struct Z
    {
      public int X { get; set; }
    }
      Z z1 = new Z();
      z1.GetType().GetProperty("X").SetValue(z1, 100, null);
      Console.WriteLine(z1.X); //z1.X dont changed
      object z2 = new Z();
      z2.GetType().GetProperty("X").SetValue(z2, 100, null);
      Console.WriteLine(((Z)z2).X); //z2.x changed to 100
      Z z3 = new Z();
      object _z3 = z3;
      _z3.GetType().GetProperty("X").SetValue(_z3, 100, null);
      z3 = (Z)_z3;
      Console.WriteLine(z3.X); //z3.x changed to 100
