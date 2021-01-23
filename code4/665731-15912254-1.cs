    public Category NewCategory
    {
        get { return _newCategory ?? (_newCategory = new Category()); }
        set
            {
              if (Equals(_newCategory, value)) return;
              _newCategory = value;
               SendPropertyChanged("NewCategory");
             }
    }
