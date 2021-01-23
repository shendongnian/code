    public event EventHandler ComboboxClick
    {
       add { _combobox.Click += value; }
       remove { _combobox.Click -= value; }
    }
