    class Symbols
    {
    public string Name{get;set;}
    }
    var Symb= new List<Symbols> { new Symbols() { Name = "Abc"}, new Person() { Name = "BC" }};
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = Symb;
            comboBox1.DataBindings.Add("SelectedItem", Symb, "Name");
