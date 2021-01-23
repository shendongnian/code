    Form2 MyForm2 = new Form2();
    MyForm2.OnMyChange += MyChanged;
    static void MyChanged(object source, MyEventArgs e)
    {
        //e.EventInfo will contain list
    	Console.WriteLine("changed");
    }
