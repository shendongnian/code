     //this collection just init once - eg. in ctor, use add, remove, clear to alter
     public ObservableCollection<CustomVariableGroup> CustomVariableGroups {get; private set; }
     //create just once in ctor
     public ICollectionView MyView {get; private set;}
     //ctor
     this.CustomVariableGroups = new ObservableCollection<CustomVariableGroup>();
     this.MyView = CollectionViewSource.GetDefaultView(this.CustomVariableGroups);
     //in your disabled property set the filter
        public bool ShowDisabled
        {
            get { return _showDisabled; }
            set { 
                _showDisabled = value;
                if (_showDisabled)
                    //show just disabled
                    this.MyView.Filter = (item) =>
                                             {
                                                 var myitem = (CustomVariableGroup) item;
                                                 return myitem.Disabled;
                                             };
                else
                {
                    //show all
                    this.MyView.Filter = (item) => { return true; };
                }
                
                this.NotifyPropertyChanged("ShowDisabled"); }
        }
