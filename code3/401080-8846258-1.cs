    public event RoutedEventHandler Click
    {
        add { this.button.Click += value; }
        remove { this.button.Click -= value; }
    }
