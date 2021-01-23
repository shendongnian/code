      public decimal SelectedSystemUserCode
     {
        get{
              if(_selectedSystemUserCode==null)
                  {
                          _selectedSystemUserCode=default(decimal);
                  }
            return _selectedSystemUserCode;
          }
        set
          {
         _selectedSystemUserCode=value;
          FirePropertyChanged("SelectedSystemUserCode"); 
          //This will be messanger for our binding
          }
       }
