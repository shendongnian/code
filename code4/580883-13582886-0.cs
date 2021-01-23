    public class SomeClass
    {
         private readonly static object _sync = new object(); 
             
         public void WriteAllText()
         {
              lock(_sync)
              {
                   File.WriteAllText("myfile.txt", "Hello world from a synchronized file access!!!");
              }
         }
    }
