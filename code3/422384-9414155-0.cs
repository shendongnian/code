    public IEnumerable<IMyItem> MainStream
    {
       get
       {
          foreach(var item in mainDataSource)
          {
             if (item.Name == this.NameFilterBoundToUiTextBox)
             { 
                yield return item;
             }
          }
       }
    }
     
    private string nameFilter;
    public string NameFilterBoundToUiTextBox
    {
       get
       {
           return this.nameFilter;
       }
       set
       {  
          if (this.nameFilter != value)
          {
             this.nameFilter = value;
    
             // TODO: Implement INotifyPropertyChanged
             this.OnPropertyChanged("NameFilterBoundToUiTextBox");
    
             // THis would notify UI to rebind MainSream
             this.OnPropertyChanged("MainStream");
          }
       }
    }
