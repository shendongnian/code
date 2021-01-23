    public class StockItem
	{
			// Insert code required on object creation below this point.
            //      public string IDCode { get; set; }
            //      public string AvailableStock { get; set; }
            //      public string BlockedStock { get; set; }
            //      public string TotalStock { get; set; }
            //      public string DetailedInfo { get; set; }
            //      public string WarehouseName { get; set; }
            //      public string UOM { get; set; }
            //public StockItem() { }
            // public StockItem(string idcode, string avstock, string blstock, string totstock, string detinfo, string warehouse, string uom) 
            //  {
            //         this.IDCode = idcode;
            //         this.AvailableStock = avstock;
            //         this.BlockedStock = blstock;
            //         this.TotalStock = totstock;
            //         this.DetailedInfo = detinfo;
            //         this.WarehouseName = warehouse;
            //         this.UOM = uom;
            //     }
        private string _idcode;
        public string IDCode
        {
            get
            {
                return _idcode;
            }
            set
            {
                if (value != _idcode)
                {
                    _idcode = value;
                    NotifyPropertyChanged("IDCode");
                }
            }
        }
        private string _avstock;
        public string AvailableStock
        {
            get
            {
                return _avstock;
            }
            set
            {
                if (value != _avstock)
                {
                    _avstock = value;
                    NotifyPropertyChanged("AvailableStock");
                }
            }
        }
        private string _blstock;
        public string BlockedStock
        {
            get
            {
                return _blstock;
            }
            set
            {
                if (value != _blstock)
                {
                    _blstock = value;
                    NotifyPropertyChanged("BlockedStock");
                }
            }
        }
        private string _totstock;
        public string TotalStock
        {
            get
            {
                return _totstock;
            }
            set
            {
                if (value != _totstock)
                {
                    _totstock = value;
                    NotifyPropertyChanged("TotalStock");
                }
            }
        }
        private string _detinf;
        public string DetailedInfo
        {
            get
            {
                return _detinf;
            }
            set
            {
                if (value != _detinf)
                {
                    _detinf = value;
                    NotifyPropertyChanged("DetailedInfo");
                }
            }
        }
        private string _uom;
        public string UOM
        {
            get
            {
                return _uom;
            }
            set
            {
                if (value != _uom)
                {
                    _uom = value;
                    NotifyPropertyChanged("UOM");
                }
            }
        }
        private string _wareh;
        public string WarehouseName
        {
            get
            {
                return _wareh;
            }
            set
            {
                if (value != _wareh)
                {
                    _wareh = value;
                    NotifyPropertyChanged("WarehouseName");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}
