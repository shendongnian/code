        public class RadioButtonProperties
        {
            private RadioButton _realtedRadioButton = new RadioButton();
            public RadioButtonProperties(RadioButton radio)
            {
                _realtedRadioButton = radio;
                Name = radio.Name;
                Checked = radio.Checked;
                //add other properties
            }
            public string Name
            {
                get
                {
                    //logic to to handle if checkbox is null here
                    return _realtedRadioButton.Name;
                }
                set
                {
                    //logic to to handle if checkbox is null here
                    _realtedRadioButton.Name = value;
                }
            }
            public bool Checked
            {
                get
                {
                    //logic to to handle if checkbox is null here
                    return _realtedRadioButton.Checked;
                }
                set
                {
                    //logic to to handle if checkbox is null here
                    _realtedRadioButton.Checked = value;
                }
            }
        }
