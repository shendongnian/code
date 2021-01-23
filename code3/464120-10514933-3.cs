    public interface IPerson
    {
        string Name { get; set; }
        string PersonAddText(string text);
    }
    public class Person : IPerson
    {
        // your code here
    }
