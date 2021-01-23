    public abstract class Module
    {
       internal int ID;
       public abstract void ModuleStart();
    }
    public static class ModuleExtensions
    {
       public static void function1(this Module module)
       {
           innerFunction1(module.ID);
       }
       internal static void innerFunction1(int ID)
       {
            System.Console.WriteLine ("function1 called from module {0}", ID);
       }
    }
