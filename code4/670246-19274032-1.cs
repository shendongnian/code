    public void constructor()
    {
        try
        {
            IPeople cli = ProxyFactory.GetPeopleSvc();
            List<People> list = cli.GetClassification();
    
            if (list.count > 0)
            {
                ObservableCollection<People> tmp = new ObservableCollection<People>(list);
                GridName.ItemsSource = tmp;
            }
        }
        catch (Exception e)
        {
            Message.Show(e);
        }
    }
