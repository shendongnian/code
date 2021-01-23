    private string dataForTab = string.empty;
    
    
    public string DataForTab { get { return dataForTab; } }
    
    
    public Button_Click_2(...)
    {
          dataForTab = "Real Data";
          NotifyPropertyChanged("DataForTab");
    }
