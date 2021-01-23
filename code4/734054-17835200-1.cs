    public static readonly DependencyProperty PeopleProperty = DependencyProperty.Register("People", typeof(ObservableCollection<Person>), typeof(MainWindow), new UIPropertyMetadata(new ObservableCollection<Person>()));
    public ObservableCollection<Person> People
    {
        get { return (ObservableCollection<Person>)GetValue(PeopleProperty); }
        set { SetValue(PeopleProperty, value); }
    }
