      private string[] registerLabels = new string[8];
      public string[] RegisterLabels { get { return registerLabels; } }
      private bool isRegisterItemsVisible = false;
      public bool IsRegisterItemsVisible { 
           get { return isRegisterItemsVisible ; }
           set { 
               isRegisterItemsVisible = value; 
               OnPropertyChanged("IsRegisterItemsVisible"); 
               OnPropertyChanged("RegisterLabels"); 
           }
      }
