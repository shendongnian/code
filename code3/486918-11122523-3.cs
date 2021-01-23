    public class MyClass
    {
        public string _datafile;
        public MyClass()
        {
            _datafile = "Hello";
        }
        public void PrintField()
        {
            var result = this.GetType().GetField("_datafile").GetValue(this); 
            Console.WriteLine(result); // will print Hello
        }
    }
