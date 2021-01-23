    public class Foo
    {
        public static int bar = 0;
    }
    public class Baz
    {
        public static int bing = 0;
    }
    public class Main
    {
        public void myFunc(Type givenType)
        {
            switch (givenType.ToString())
            {
                case "Foo":
                    Debug.WriteLine("Bar is currently :" + Foo.bar);
                    break;
                case "Baz":
                    Debug.WriteLine("Bing is currently :" + Baz.bing);
                    break;
            }
        }
    }
