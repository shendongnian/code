    string contactName;
    public string ContactName
    {
        get 
        {
           return contactName; 
        }
        set 
        {
           contactName = value; 
           OnPropertyChanged("ContactName");
        }
    }
    private string editedName;
    public string EditedName
    {
        get { return editedName; }
        set
        {
            editedName = value;
            OnPropertyChanged("EditedName");
        }
    }
    private int selectedIndex;
    public int SelectedIndex
    {
        get { return selectedIndex; }
        set
        {
            selectedIndex = value;
            OnPropertyChanged("SelectedIndex");
        }
    }
