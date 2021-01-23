      public ObservableCollection<MasterPartNumber> AssyPns
        {
            get
            {
                    var enumerable = this._context.MasterPartNumbers.Include("MasterPartsLists").Where(t => t.MasterPartsLists.Any(x => x.isAssy == true));
                    
                
                    return this._assyPns = new ObservableCollection<MasterPartNumber>(enumerable);
                
                    
               
            }
            set 
            {
                this._assyPns = value;
                RaisePropertyChanged("AssyPns");
                
            }
        }
        
                public MasterPartNumber SelectedTopLevelAssyPN //<-- this is the selected Parent item i am getting my DataGrid's ObservableCollection from
        {
            get { return this._selectedTopLevelAssyPN; }
            set
            {
                this._selectedTopLevelAssyPN = value;
                RaisePropertyChanged("SelectedTopLevelAssyPN");
                RaisePropertyChanged("SelectedAssyBOMLineItems");
            }
        }
        public ObservableCollection<MasterPartsList> SelectedAssyBOMLineItems //<-- this is my itemsSource
        {
            get
            {
                if (this._selectedTopLevelAssyPN != null)
                {
                    var children = _context.MasterPartsLists.Where(lineItem => lineItem.parentAssyPN != null)
                                                            .Where(lineItem => lineItem.parentAssyPN == this._selectedTopLevelAssyPN.pn);     
     
                    
                    return this._selectedAssyBOMLineItems = new ObservableCollection<MasterPartsList>(children);
                }
                return this._selectedAssyBOMLineItems;
            }
            set
            {
                this._selectedAssyBOMLineItems = value;
                RaisePropertyChanged("SelectedAssyBOMLineItems");
            }
        }
       
