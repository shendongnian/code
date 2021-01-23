    class ViewItem {
       public string Name { get;set;}
       public string Value { get;set;}
    }
    ...
    BindingList<ViewItem> list=  new BindingList<ViewItem>();
    dataGridView.DataSource = list;
    ViewItem vi = new ViewItem(){Name = "Foo", Value = "Bar"};
    list.Add(vi);
    /// works!
