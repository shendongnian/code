    private int tabIndex;
            public int TabIndex
            {
                get { return tabIndex; }
                set
                {
                    tabIndex = value;
                    NotifyPropertyChanged("TabIndex");
    
                    ResetTextBoxes();
                }
            }
    
            private void ResetTextBoxes()
            {
                TextValue1 = "12";
                TextValue2 = string.Empty;
                TextValue3 = "default";
            }
    
            private string textValue1;
            public string TextValue1
            {
                get { return textValue1; }
                set
                {
                    textValue1 = value;
                    NotifyPropertyChanged("TextValue1");
                }
            }
    
            private string textValue2;
            public string TextValue2
            {
                get { return textValue2; }
                set
                {
                    textValue2 = value;
                    NotifyPropertyChanged("TextValue2");
                }
            }
    
            private string textValue3;
            public string TextValue3
            {
                get { return textValue3; }
                set
                {
                    textValue3 = value;
                    NotifyPropertyChanged("TextValue3");
                }
            }
