     public Customer Customer
            {
                get 
                { 
                    return customer; 
                }
                set
                {
                    customer = value;
                    RaisePropertyChanged(PropertyName(() => this.Customer));
                }
            }
