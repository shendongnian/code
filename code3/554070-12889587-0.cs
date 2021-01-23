        ObservableCollection<VoltageModel> _voltages;
        public ObservableCollection<VoltageModel> VoltageCollection {
        
         get {return voltages;}
         set 
         {
         _volgates=value;
          PropertyChanged("VoltageCollection");
        
         }
