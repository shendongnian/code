    public interface IOutput
    {
        void Print(Person person);
    }
    public class ConsoleOutput : IOutput
    {
        public void Print(Person person)
        {
            Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public static class SampleContext
    {
        public static IOutput Output { get; set; }
    }
    public static class ExtensionMethods
    {
        public static void Print(this Person person)
        {
            SampleContext.Output.Print(person);
        }
    }
    static class Program
    {
        static void Main()
        {
            //You would use your DI framework here
            SampleContext.Output = new ConsoleOutput();
            //Then call the extension method
            var person = new Person()
            {
                FirstName = "Louis-Pierre",
                LastName = "Beaumont"
            };
            person.Print();
        }
    }
