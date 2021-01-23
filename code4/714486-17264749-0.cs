        public class FilterListViewModel : INotifyPropertyChanged
    {
    MyEntities context = new MyEntities();
    ObservableCollection<string> entries = new ObservableCollection<string>();
    public Type SelectedType;
    private string p_TypeName;
    public string TypeName
    {
        get { return p_TypeName; }
        set { 
            //p_TypeName = value; 
            p_TypeName = SelectedType.Name.ToString();
      NotifyPropertyChanged();
        }
    }
    public FilterListViewModel() { }
    public FilterListViewModel(Type selectedType)
    {
        if (selectedType == typeof(Artist))
        {
            returnedArray = Artist.ReturnArtistNames(context);
        }
        // put together ObservableCollection
        foreach (var str in returnedArray)
        {
            entries.Add(str);
        }
        SelectedType = selectedType;
    }
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
     }
