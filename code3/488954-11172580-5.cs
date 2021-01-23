    public MyListBox() : base()
    {
        this.SelectionChanged += OnSelectionChanged;
        this.PreviousSelectedIndex = -1;
    }
     
    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(e.RemovedItems.Count == 0)
        {
            this.PreviousSelectedIndex = -1;
        }
        else
        {
            this.PreviousSelectedIndex = this.Items.IndexOf(e.RemovedItems[0]);
        }
    }
