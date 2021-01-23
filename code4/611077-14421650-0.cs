    private bool _showChildItems;
    public Visibility showChildItems
    {
        get
        {
            if (_showChildItems)
                return System.Windows.Visibility.Visible;
            else
                return System.Windows.Visibility.Collapsed;
        }
    }
