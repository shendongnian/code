     public void FirePropertyChanged(string prop)
     {
         if(PropertyChanged!=null)
         {
           PropertyChanged(prop);
          }
      }
