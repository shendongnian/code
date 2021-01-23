    public void ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        MyObject item = e.SelectedItem as MyObject;
        Debug.WriteLine("Selected item Id: " + item.id);
        Debug.Writeline("Selected item Name: " + item.name);
    }
