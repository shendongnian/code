    <TextBox Text="{Binding SearchText}" />
    private string _searchText;
    public string SearchText
    {
        get { return _searchText; }
        set
        {
            _searchText = value;
            // Change contents of list box.
        }
    }
