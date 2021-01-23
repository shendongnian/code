    public class Customer : INotifyPropertyChanged
    {
        public Customer()
        {
            this.Invoices.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Invoices_CollectionChanged);
        }
    
        ObservableCollection<Invoice> Invoices 
        {
            get;
            set;
        }
    
        public int TotalOpenInvoices
        {
            get
            {
                if (Invoices != null)
                    return (from i in Invoices
                            where i.PayedInFull == false
                            select i).Count();
                else return 0;
            }
        }
    
    
        void Invoices_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (Invoice invoice in e.NewItems)
                invoice.PropertyChanged += new PropertyChangedEventHandler(invoice_PropertyChanged);
    
            foreach (Invoice invoice in e.OldItems)
                invoice.PropertyChanged -= new PropertyChangedEventHandler(invoice_PropertyChanged);
        }
    
        void invoice_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PayedInFull")
                NotifyPropertyChanged("TotalOpenInvoices");
        }
    
        #region INotifyPropertyChanged Members
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        #endregion
    }
