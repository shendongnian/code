        private UITextAlignment _alignment;
        public UITextAlignment Alignment
        {
            get { return _alignment; }
            set { _alignment = value; UpdateCaptionDisplay(CurrentAttachedCell);}
        }
        private TValueType _value;
        public TValueType Value
        {
            get { return _value; }
            set { _value = value; UpdateDetailDisplay(CurrentAttachedCell); }
        }
