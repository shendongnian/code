    namespace SO
    {
      using System;
      using System.IO;
      using System.Runtime.Serialization.Formatters.Binary;
      [Serializable]
      public class Employee
      {
        public string Name { get; set; }
        public string Id { get; set; }
      }
      public class Test
      {
        public static void Main()
        {
          var emp = new Employee { Id = "1" };
          //Name field is intentionally uninitialized
          using (var stream = File.Open("Sample.erl", FileMode.Create))
          {
            var bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, emp);
          }
          using (var stream = File.Open("Sample.erl", FileMode.Open))
          {
            var bformatter = new BinaryFormatter();
            var empFromFile = (Employee)bformatter.Deserialize(stream);
            Console.WriteLine(empFromFile.Id);
            Console.ReadLine();
          }
        }
      }
    }
