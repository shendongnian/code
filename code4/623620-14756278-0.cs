    public class Parent
    {
        public int Value { get; set; }
        public Parent()
        {
            Value = 5;
        }
    }
    public class Child : Parent
    {
        public string Text { get; set; }
        public Child(string text)
            : base()  //note this line can be omitted; the compiler will add it automatically
        {
            Text = text;
        }
    }
