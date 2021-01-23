            MyTreeViewItem a = new MyTreeViewItem("A");
            a.SomeItems.Add(new MyTreeViewItem("A1"));
            a.SomeItems.Add(new MyTreeViewItem("A2"));
            a.SomeItems.Add(new MyTreeViewItem("A3"));
            MyTreeViewItem b = new MyTreeViewItem("B");
            b.SomeItems.Add(new MyTreeViewItem("B1"));
            b.SomeItems.Add(new MyTreeViewItem("B2"));
            b.SomeItems.Add(new MyTreeViewItem("B3"));
            this.MyTreeView.ItemsSource = new MyTreeViewItem[] { a, b };
