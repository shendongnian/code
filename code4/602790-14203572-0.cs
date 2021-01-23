    public class Foo
    {
        private string _bar;
        public static string Bar  <-- would very much want to keep this static
        {
            get { return _bar; }
            set { _bar = value; }
        }
    }
