    class Program
    {
      static Program()
      {
         AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
      }
    
      static void Main(string[] args)
      {
        // what was here is the same
      }
    
      static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
      {
          // the rest of sample code
      }
    
    }
