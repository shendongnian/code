    public bool CheckAll
     {
          get { return _checkAll; }
          set
          {
               if (_checkAll == value)
                    return;
               _checkAll = value;
               _items.Where(ItemsView.Filter.Invoke).Select(i=>i.IsChecked=_checkAll);
               OnPropertyChanged("CheckAll");
          }
     }
