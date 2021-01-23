    ChildViewModel n = new ChildViewModel()
    n.PropertyChanged += new PropertyChangedEventHandler(n_PropertyChanged);
    void n_PropertyChanged(object sender, PropertyChangedEventArgs e)
    { if(e.PropertyName == "myChangingObject")
    //reload list
    }
