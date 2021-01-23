    public class MagazineViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
      private string navn;
      private string pris;
      private string error;
      public string Navn
      {
        get { return navn; }
        set
        {
          if (navn != value)
          {
            navn = value;
            RaisePropertyChanged("Navn");
          }
        }
      }
      public string Pris
      {
        get { return pris; }
        set
        {
          if (pris != value)
          {
            pris = value;
            RaisePropertyChanged("Pris");
          }
        }
      }
      public string Error
      {
        get { return error; }
        set
        {
          if (error != value)
          {
            error = value;
            RaisePropertyChanged("Error");
          }
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
      public string this[string columnName]
      {
        get
        {
          var result = string.Empty;
          switch (columnName)
          {
            case "Pris":
              if (string.IsNullOrWhiteSpace(Pris))
              {
                result =  "Pris is required";
              }
              break;
            case "Navn":
              if (string.IsNullOrWhiteSpace(Navn))
              {
               result =  "Navn is required";
              }
              break;
          }
          return result;
        }
      }
      private void RaisePropertyChanged(string PropertyName)
      {
        var e = PropertyChanged;
        if (e != null)
        {
          e(this, new PropertyChangedEventArgs(PropertyName));
        }
      }
    }
