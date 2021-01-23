    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        array = new string[listbox.Items.Count];
        ExchangeSort(array);
        listBox.Items.Clear();
        foreach (string i in array)
        {
            listBox.Items.Add(i);
        }
        MessageBox.Show("Done");
    }
