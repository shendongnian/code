    StringCollection dict = Settings.Default.MyDict; 
    // put your string in the wrapper
    List<MyString> anotherdict = new List<MyString>();
    foreach (string str in dict)
    {
        anotherdict.Add(new MyString(str));
    }
    BindingSource bs = new BindingSource();
    // bind to the new wrapper class
    bs.DataSource = anotherdict;
    this.DGV.DataSource = bs; 
