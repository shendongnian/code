        listBox1.SelectionChanged += new SelectionChangedEventHandler (listBox1_SelectionChanged);
    void listBox1_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            foreach (Settings item in e.AddedItems)
            {
                item.OnOff = !item.OnOff;
            }
        }
