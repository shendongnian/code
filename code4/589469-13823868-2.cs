    class Program
    {
      static event AssemblyLoadEventHandler MyEvent;
      static int callCount;
      static void Main(string[] args)
      {
         MyEvent += SingleUseEventHandler<AssemblyLoadEventArgs, AssemblyLoadEventHandler>
            .Create(Load);
         
         foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
         {
            Console.WriteLine("Raising event for " + assembly.GetName().Name);
            MyEvent(null, new AssemblyLoadEventArgs(assembly));
         }
      }
      static void Load(object sender, AssemblyLoadEventArgs eventArgs)
      {
         Console.WriteLine(++callCount);
      }
    }
