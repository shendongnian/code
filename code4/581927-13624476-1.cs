    class MutableReadonly
    {
      public readonly Mutable M = new Mutable {X = 1};
    }
    
    // Somewhere in the code
    var mr = new MutableReadonly();
    
    // Illegal!
    mr.M = new Mutable();
    
    // Illegal as well!
    mr.M.X++;
    
    // Legal but lead to undesired behavior
    // becaues mr.M.X remains unchanged!
    mr.M.ChangeX(10);
