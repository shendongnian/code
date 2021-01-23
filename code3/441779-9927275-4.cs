    public interface ICommonInterface
    {
        int Number { get; }
        string Text { get; }
    }
    public Class1 : ICommonInterface
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public string AnAdditionalProperty { get; set; }
    }
    public NumberWrapper : ICommonInterface
    {
        public NumberWrapper (int number)
        {
            this.Number = number;
            this.Text = number.ToString();
        }
        public int Number { get; private set; }
        public string Text { get; private set; }
    }
    public TextWrapper : ICommonInterface
    {
        public TextWrapper (string text)
        {
            this.Text = text;
            int i;
            Int32.TryParse(text, out i);
            this.Number = i;
        }
        public int Number { get; private set; }
        public string Text { get; private set; }
    }
