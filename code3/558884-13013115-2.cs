    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.Source is TabControl)
        {
            TabItem tabitem = e.AddedItems[0] as TabItem;
            if (tabitem == null)
                return;
            Tab2 tab2 = tabitem.Content as Tab2;
            if (tab2 == null)
                return;
            tab2.textBox1.Text = "zxczxczxczxc";
        }
    }
