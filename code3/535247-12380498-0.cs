    public class Foo  {
        public string Bar { get; set; }
        public string Baz { get; set; }
    }
    
    class Program {
        public static void Main() {
            Foo f = new Foo();
            var wrapped = ObjectAccessor.Create(f);
            string propName = "Baz";
            wrapped[propName] = "Ah ha";
            Console.WriteLine(f.Baz);  //Prints Ah ha
        }
    }
