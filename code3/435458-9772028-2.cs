    public interface IYourInterface
    {
        Action<string> YourAction { get; }
    }
    public class Foo : IYourInterface
    {
        public Action<string> YourAction { get; set; }
    }
