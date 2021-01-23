    using System.IO;
    
    namespace ConsoleApplication3 {
    
        partial class Program {
            
            static void Main(string[] args) {
                Generate();
            }
                
            static void Generate() {
    
                StreamWriter sw = new StreamWriter(@"Program_Generated.cs");
                sw.WriteLine("using ConsoleApplication3;");
                sw.WriteLine("partial class Program {");
    
                string template = "\tCar car# = new Car() { Id = #, Name = \"Car #\" };";
                for (int i = 1; i <= 100; i++) {
                    sw.WriteLine(template.Replace("#", i.ToString()));
                }
    
                sw.WriteLine("}");
                sw.Flush();
                sw.Close();
            }
        }    
    
        class Car {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
