      public enum PersonName
      {
          Eric,
          George,
          David,
          Frank
      }
      private PersonName myPersonName
      public PersonName MyPersonName
      {
          get { return myPersonName; }
          set
          {
              myPersonName = value;
              //simply call what you want done
              PersonNamePropertyChanged();
          }
      }
