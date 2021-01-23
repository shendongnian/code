    // This is a simple customer class that 
    // implements the IPropertyChange interface.
    public class DemoCustomer  : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;    
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
              PropertyChanged(this, new PropertyChangedEventArgs(info));            
        }
    
        public string CustomerName
        {
            //getter
            set
            {
                if (value != this.customerNameValue)
                {
                    this.customerNameValue = value;
                    NotifyPropertyChanged("CustomerName");
                }
            }
        }
    }
