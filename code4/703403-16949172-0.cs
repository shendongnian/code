    public class ModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            OnErrorChanged(propertyName);
        }
        protected void OnErrorChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public virtual IEnumerable GetErrors(string propertyName)
        {
            return Enumerable.Empty<string>();
        }
        public virtual bool HasErrors
        {
            get { return false; }
        }
    }
    public class Customer : ModelBase
    {
        public Customer()
        {
            Orders.CollectionChanged += Orders_CollectionChanged;
        }
        void Orders_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems.Count > 0)
                foreach (INotifyPropertyChanged item in e.OldItems)
                    item.PropertyChanged -= Customer_PropertyChanged;
            if (e.NewItems.Count > 0)
                foreach (INotifyPropertyChanged item in e.NewItems)
                    item.PropertyChanged += Customer_PropertyChanged;
            OnPropertyChanged("TotalSales");
        }
        void Customer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Total")
                OnPropertyChanged("TotalSales");
        }
        public decimal TotalSales
        {
            get { return Orders.Sum(o => o.Total); }
        }
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName == value)
                    return;
                _FirstName = value;
                OnPropertyChanged();
            }
        }
        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName == value)
                    return;
                _LastName = value;
                OnPropertyChanged();
            }
        }
        private readonly ObservableCollection<Order> _Orders = new ObservableCollection<Order>();
        public ObservableCollection<Order> Orders
        {
            get { return _Orders; }
        }
    }
    public class Order : ModelBase
    {
        public Order()
        {
            OrderLines.CollectionChanged += OrderLines_CollectionChanged;
        }
        void OrderLines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems.Count > 0)
                foreach (INotifyPropertyChanged item in e.OldItems)
                    item.PropertyChanged -= OrderLine_PropertyChanged;
            if (e.NewItems.Count > 0)
                foreach (INotifyPropertyChanged item in e.NewItems)
                    item.PropertyChanged += OrderLine_PropertyChanged;
            OnPropertyChanged("Total");
            OnErrorChanged("");
        }
        public override bool HasErrors
        {
            get { return GetErrors("").OfType<string>().Any() || OrderLines.Any(ol => ol.HasErrors); }
        }
        void OrderLine_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Extension")
                OnPropertyChanged("Total");
        }
        public decimal Total
        {
            get { return OrderLines.Sum(o => o.Extension); }
        }
        private int _OrderNumber;
        private DateTime _OrderDate;
        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set
            {
                if (_OrderDate == value)
                    return;
                _OrderDate = value;
                OnPropertyChanged();
            }
        }
        public int OrderNumber
        {
            get { return _OrderNumber; }
            set
            {
                if (_OrderNumber == value)
                    return;
                _OrderNumber = value;
                OnPropertyChanged();
            }
        }
        private readonly ObservableCollection<OrderLine> _OrderLines = new ObservableCollection<OrderLine>();
        public ObservableCollection<OrderLine> OrderLines
        {
            get { return _OrderLines; }
        }
    }
    public class OrderLine : ModelBase
    {
        private string _ProductName;
        private decimal _Quantity;
        private decimal _Price;
        public decimal Price
        {
            get { return _Price; }
            set
            {
                if (_Price == value)
                    return;
                _Price = value;
                OnPropertyChanged();
            }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                if (_ProductName == value)
                    return;
                _ProductName = value;
                OnPropertyChanged();
                OnPropertyChanged("Extension");
            }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set
            {
                if (_Quantity == value)
                    return;
                _Quantity = value;
                OnPropertyChanged();
                OnPropertyChanged("Extension");
            }
        }
        public decimal Extension
        {
            get { return Quantity * Price; }
        }
        public override IEnumerable GetErrors(string propertyName)
        {
            var result = new List<string>();
            if ((propertyName == "" || propertyName == "Price") && Price < 0)
                result.Add("Price is less than 0.");
            if ((propertyName == "" || propertyName == "Quantity") && Quantity < 0)
                result.Add("Quantity is less than 0.");
            return result;
        }
        public override bool HasErrors
        {
            get { return GetErrors("").OfType<string>().Any(); }
        }
    }
