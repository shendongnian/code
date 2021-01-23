 namespace ConsoleApp
 {
      class Progam
      {
           static ... Main()
           {
                Program program = new Program();
                program.receipt();
                // or static method
                Program.receipt_static(); 
           }
           public static void receipt_static()
           {
            ...
           }
      }
   public void receipt()
  { ... }
 }
}
