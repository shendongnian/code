    public void ProcessFile(string path)
    {
        myListBox.Items.Add(path);
        myListBox.ScrollIntoView(myListBox.Items[myListBox.Items.Count-1]);
        Dispatcher.Invoke(new Action(delegate { }), DispatcherPriority.Background);
    }
