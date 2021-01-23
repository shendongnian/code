    using ComponentLibrary;
    class Program
    {
      static void Main()
      {
        //...
        if (Module1.IsActive()) listModules.Add(Library.Module1);
        if (Module2.IsActive()) listModules.Add(Library.Module2);
      }
      listModules_click()
      {
         // var m = clicked-on-module
         if (m is Module1)
         {
           component = new Module1();
         }
         else if (m is Module2)
         {
           component = new Module2();
         }
      }
    }
    namespace ComponentLibrary
    {
      abstact class Module : Component
      {
         public abstract bool IsActive();
      }
      public class Module1 : Module
      {
         public bool IsActive() { return true; }
      }
      public class Module2 : Module
      {
         public bool IsActive() { return false; }
      }  
    }
