     Public Int SelectedIndex 
     {
          get { return selectedindex; }  
     }
     public void mysub()
     {
          selectedindex = 2; 
          NotifyPropertyChanged("SelectedIndex");
     }
         
        
