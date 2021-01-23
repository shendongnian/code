    public Image GridAContent
    {
        get
        {
            return this.Items.First();
        }
    }
    
    public ObservableCollection<Image> GridBContent
    {
        get
        {
            return this.Items.Skip(1);
        }
    }
