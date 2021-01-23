    public event EventHandler ButtonClick
    {
        add
        {
            button1.Click += value;
        }
        remove
        {
            button1.Click += value;
        }
    }
