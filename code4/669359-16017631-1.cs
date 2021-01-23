    private string customerNameValue = String.Empty;
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
