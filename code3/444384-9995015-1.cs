    codeClass.PropertyChanged += codeClass_PropertyChanged;
    ...
    void codeClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName = "MyProperty")
        {
            ...
        }
    }
