    public interface ITestMethod { string Test();}
    public class Person : ITestMethod
    {
        public Person() { }
        public string Test() { return string.Format("Person - {0}", this.ToString()); }
    }
    public class Organization : ITestMethod
    {
        public Organization() { }
        public string Test() { return string.Format("Org - {0}", this.ToString()); }
    }
    //...
    public void Demo()
    {
        var myInstance = Activator.CreateInstance((new Person()).GetType()) as ITestMethod;
        Console.WriteLine(myInstance.Test());
    }
    //...
