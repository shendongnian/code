    class MyModel
    {
        public string Text { get; set; }
    }
    class MyViewModel : MyModel
    {
        public new string Text
        {
            get { return base.Text; }
            set { base.Text =value.ToUpper(); }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyViewModel mvm = new MyViewModel();
            mvm.Text = "hello there";
            var s = ((MyModel) mvm).Text; // "HELLO THERE"
        }
    }
