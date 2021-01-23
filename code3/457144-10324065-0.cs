    //in the ViewModel
    public Person Model
    {
       get { return _person; }
       set { _person = value; 
             RaisePropertyChanged("Model");  //<- this should tell the view to update
            }
    }
