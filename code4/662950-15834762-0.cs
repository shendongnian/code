    using System;
    public class BaseModel
    {
        public string getName()
        {
            return (string) this.GetType().GetProperty("Name").GetValue(this, null);
        }
    }
    public class SubModel : BaseModel
    {
        public string Name { get; set; }
    }
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                SubModel b = new SubModel();
                b.Name = "hello";
                System.Console.Out.WriteLine(b.getName()); //prints hello
            }
        }
    }
