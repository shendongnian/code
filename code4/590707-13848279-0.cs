    public class ScreenGroupModel
        {       
    
            private ObservableCollection<object> _groupItems = new ObservableCollection<object>();
    
           
            public ObservableCollection<object> GroupItems
            {
                get { return this._groupItems; }
            }
         
            public ScreenGroupModel()
            {
    
            }      
    
          
            public ObservableCollection<object> GetScreenGroups()
            {            
                _groupItems.Add(new Class1);
                _groupItems.Add(new Class2);           
    
                return _groupItems;
            }       
        }
