    public class MyClass
    {
        private string txt;
        public string SomeWeirdText
        {
            get { return this.txt; }
            set
            {
                if (value != "bar")
                    throw new ArgumentException();
                this.txt = value;
            }
        }
    }
