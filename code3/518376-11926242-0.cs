    abstract class Car
    {
      public string Name { get; set; }
    
      public void StartEngine()
      {
        if (CheckGasoline())
            StartEngineOverride();
      }
    
      protected abstract void StartEngineOverride();
      protected abstract bool CheckGasoline();
    
      // ...
    }
    
    class Mercedes : Car
    {
      protected override bool CheckGasoline()
      {
         //somehow check gasoline and return whatever...
      }
    
      protected override void StartEngineOverride()
      {
         // CheckGasoline was already checked, so just do the override portion.
      }
    }
