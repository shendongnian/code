    private bool visibilityOfLabel;
    public bool VisibilityOfLabel 
    {
         get
         {
             return visibilityOfLabel;
         } 
         
         set
         {
             visibilityOfLabel = value;
             RaisePropertyChanged("VisibilityOfLabel");
         }
    }
