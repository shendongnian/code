    void Main()
    {
         MyClass mc = new MyClass(10);
         mc.ValueChanged += _ValueChanged;
         mc.Value = 100;
    }
    void _ValueChanged(object sender, ValueChangedEventArgs e)
    {
         Console.WriteLine(e.LastValue.ToString()); //This print -> 10
         Console.WriteLine(e.NewValue.ToString());  //This print -> 100
    } 
