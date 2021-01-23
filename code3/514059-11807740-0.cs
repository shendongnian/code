        private RadioButtonEnum _radioButtonEnum
        public RadioButtonEnum RadioButtonEnum
        {
            get { return _radioButtonEnum; }
            set
            {
                _radioButtonEnum = value;
                OnPropertyChanged("RadioButtonEnum");
                RefreshText();
            }
        }
        private void RefreshText()
        {
            switch (RadioButtonEnum)
            {
                case None:
                    //Do your changes to your TextProperty
                    break;
                case All:
                    //Do your changes to your TextProperty
                    break;
                case One:
                    //Do your changes to your TextProperty
            }
            OnPropertyChanged("YourTextProperty");
        }
