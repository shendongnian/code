     private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
     {
          if(e.PropertyName == "Prop1") RaisePropertyChanged("SpecicalProperty");
          ...
     }
 
      public string SpecicalProperty
      {
         get
         {
             reutrn Model.Prop1 + " some additional logic for the view"; 
         }
       }
