    void Main()
    {
         Values test = new Values(10);
         test.ValueChanged += _ValueChanged;
         test.Value = 100;
         test.Value = 1000;
         test.Value = 2000;
    }
    void _ValueChanged(object sender, ValueChangedEventArgs e)
    {
         Console.WriteLine(e.LastValue.ToString());
         Console.WriteLine(e.NewValue.ToString());
    } 
