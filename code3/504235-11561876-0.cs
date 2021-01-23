     public string MySelectedItem
     {
       get{return this._myselecteditem;}
       set{this._myselecteditem=value; OnPropertyChanged("MySelectedItem");}
     }
