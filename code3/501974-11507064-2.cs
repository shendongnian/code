    public class Foo
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public Foo(int id, string name)
        {
            Value = id;
            Text = name;
        }
        public override string ToString()
        {
            return Text;
        }
    }
