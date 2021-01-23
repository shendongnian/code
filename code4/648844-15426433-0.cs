    MyBindingSource.Clear();
    MyBindingSource.Add(new BusinessObject("Bill", "Clinton", 1946));
    MyBindingSource.Add(new BusinessObject("George", "Bush", 1946));
    MyBindingSource.Add(new BusinessObject("Barack", "Obama", 1961));
    
    lstBox.DataSource = MyBindingSource;
