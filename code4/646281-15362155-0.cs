    namespace ConsoleApplication1
    {
      using System;
      
      internal class ClassA : IClassA
      {
        public ClassA(string id)
        {
          this.Id = id;
        }
        public string Id { get; private set; }
      }
      public interface IClassA
      {
          string Id{ get; }
      }
      class Program
      {
        static void Main()
        {
          var a = new ClassA("Test");
          Console.WriteLine(a.Id);
          
          Console.ReadLine();
        }
      }
    }
