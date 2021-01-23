        public class RadioButtonProperties
        {
            public string Name { get; set; }
            public bool Checked { get; set; }
            //add other properties you want to allow access to.
            public RadioButtonProperties(RadioButton radio)
            {
                Name = radio.Name;
                Checked = radio.Checked;
                //add other properties
            }
            public void CopyTo(ref RadioButton radio)
            {
                radio.Name = Name;
                radio.Checked = Checked;
                //add other properties
            }
        }
        public class RadioButtonPropertiesList
        {
            private RadioButton[] _items;
            public RadioButtonProperties this[int index]
            {
                get
                {
                    return new RadioButtonProperties(_items[index]);
                }
                set
                {
                    RadioButton toChange = null;
                    if(_items != null && index < _items.Length)
                        toChange = _items[index];
                    if(toChange == null)
                    {
                        //do code to properly create array (if null or too small) and radiobox. 
                    }
                    value.CopyTo(ref toChange);
                }
            }
        }
