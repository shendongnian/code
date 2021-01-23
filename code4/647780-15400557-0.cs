        private bool _IsOn;
        public bool IsOn
        {
            get
            {
                return _IsOn;
            }
            set
            {
                _IsOn = value;
                OrdersButton.Text = _IsOn ? "On" : "Off";
            }
        }
