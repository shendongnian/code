    ListViewItem item = (MyObject)MyListView.SelectedItems[0];
    MyObject foo = new MyObject();
    foo.FirstName = item.Text;
    foo.LastName = item.SubItems[1].Text;
    foo.Age = Int32.Parse(item.SubItems[2].Text);
