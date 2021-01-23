    public class Item : INotifyOfPropertyChanged
    {
    public string Name;
    private ObservableCollection<MyActionString> _actions;
    public ObservableCollection<MyActionString> Actions
    {
        get { return _actions?? (_actions= new ObservableCollection<MyActionString>); }
    }
    private MyActionString _selectedAction;
    public MyActionString SelectedAction
    {
        get { return _selectedAction; }
        set { _selectedAction = value; }
    }
    }
