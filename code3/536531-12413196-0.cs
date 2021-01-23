        public string BlahIschecked
    {
    set {
           _blahIsChecked = value;
            NotifyPropertyChanged(this, new Prop..("BlahIsChecked")));
        }
    }
