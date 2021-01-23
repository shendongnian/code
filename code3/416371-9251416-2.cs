    // Clear the listbox.
    // If you never add items with listBox1.Items.Add(item); you can drop this statement.
    listBox1.Items.Clear();
    // Create the list once.
    List<Taskonlistbox> dataSource = new List<Taskonlistbox>(); 
    // Loop through the tasks and add items to the list.
    for (int i = 0; i < tasks.Count(); i++) { 
        dataSource.Add(new Taskonlistbox {Text = "Blalalalala"} ); 
    }
    // Assign the list to the `ItemsSouce` of the listbox once.
    this.listBox1.ItemsSource = dataSource;
