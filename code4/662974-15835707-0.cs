    class MyControl : Control {
        public new Padding Padding {
            get { return base.Padding; }
            set {
                // override value
                //...
                base.Padding = value;
            }
        }
    }
