     using System.ComponentModel
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
                        NotifyPropertyChanged();
                    }
                }
            }
