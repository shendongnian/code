     private string _selected = "";
     public string Selected
     {
          get{ return _selected; }
          set
          {
                if(_selected == value) return;
                _selected = value;
                base.OnPropertyChanged("Selected");
          }
     }
