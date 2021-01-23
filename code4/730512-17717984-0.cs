    public interface IFooFormater
    {
        string Format(Foo foo, int indent);
        string Format(Bar bar, int indent);
        string Format(Baz baz, int indent);
    }
    public class FooFormater : IFooFormater
    {
        public string Format(Foo foo, int indent)
        {
            return "";
        }
        public string Format(Bar bar, int indent)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("{0}Bar <Qux={1}>\n", new String(' ', indent), bar.Qux));
            foreach (var child in bar.Children)
            {
                sb.Append(this.Format((dynamic)child , indent + 1));
            }
            return sb.ToString();            
        }
        public string Format(Baz baz, int indent)
        {
            return String.Format("{0}Baz <Quux={1}>\n", new String(' ', indent), baz.Quux);
        }
    }
    public static class Extension
    {
        public static string ToText(this Foo foo, IFooFormater fooFormater)
        {
            return fooFormater.Format((dynamic)foo, 0);
        }
    }
