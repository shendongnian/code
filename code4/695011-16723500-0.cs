        public virtual bool Prop1
        {
           get
           {
                return _prop1;
           }
           set
           {
                if (_prop1 != value)
                {
                    _prop1 = value;
                    NotifyOfPropertyChange("IsDirty");
                }
           }
