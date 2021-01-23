    private class  TabSource 
    {
       private string dataForTab = string.empty; 
       public string DataForTab { get { return dataForTab; } } 
       public void GetRealData()
       {
          dataForTab = "Real Data";
          NotifyPropertyChanged("DataForTab");
       }
    }
    
    
    public Button_Click_2(...)
    {
        MyTabSource.GetRealData();       
    }
