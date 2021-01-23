    class Program
    {
        [MyAttribute]
        static void Main()
        {
        }
    }
    class MyAttribute : Attribute
    {
        public MyAttribute()
        {
            MessageBox.Show("MyAttribute ctor");
        } 
    }
