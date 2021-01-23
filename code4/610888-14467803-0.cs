    public class WrapperClass{
        public WrapperClass(StockEntity se)
        {
            this._stock = se;
        }
        private StockEntity _stock;
        public stock {
            get { return _stock; }
            set { _stock = value; }
        }
        public string BindingProperty {
            get
            {
                // use reflection to return value
                return StockModel.GetStockData(this._stock);
            }
            set
            {
                // use reflection to set value
                StockModel.SetStockData(ref this._stock);
            }
        }
    }
