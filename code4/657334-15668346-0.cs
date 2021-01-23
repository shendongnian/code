    class C
    {
      object obj = null;
      Action action;
      void M()
      {
        N();
        action();
      }
      void N()
      {
         try
         {
           action = ()=>{Console.WriteLine(obj.ToString());};
         }
         catch (Exception ex) 
         { 
           Console.WriteLine("caught!");
         }
      }
