    public bool SelectAll
    {
      get{return this._selectAll;}
      set
      {
         this._selectAll = value;
         this.MyItemsSourceCollection.ForEach(x=>x.MyRowCheckProperty=value);
         this.OnPropertyChanged("SelectAll");
      }
    }
