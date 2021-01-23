    MyClass myClass = new MyClass();
    myClass.PropertyA = "A";
    myClass.PropertyB = "B";
    myClass.PropertyC = "C";
    myClass.PropertyD = "D";
    
    ListViewItem item = new ListViewItem();
    item.Text = myClass.PropertyA;
    item.SubItems.Add(myClass.PropertyB);
    item.SubItems.Add(myClass.PropertyC);
    item.Tag = myClass;
