     private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
     {
          string[] props;
          if(_mapping.TryGetValue(e.PropertyName, out props))
          {
              foreach(var prop in props)
                  RaisePropertyChanged(prop);
          } 
     }
