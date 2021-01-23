    public interface IMyClass
    {
        MvcHtmlString Render();
    }
    public class MyClass : IMyClass
    {
        private readonly string _value;
        public MyClass(string value)
        {
            _value = value;
        }
        public MvcHtmlString Render()
        {
            return new MvcHtmlString(string.Concat("<h1>", _value, "</h1>"));
        }
    }
