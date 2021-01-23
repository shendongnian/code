            public event PropertyChangedEventHandler PropertyChanged;
            public string CustomerName
            {
                get
                {
                    return this.customerNameValue;
                }
    
                set
                {
                    if (value != this.customerNameValue)
                    {
                        this.customerNameValue = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("CustomerName"));
                        }
                    }
                }
            }
