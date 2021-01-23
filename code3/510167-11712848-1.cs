	public struct Item
	{
		public string _name { get; set; }
		private double _weightInternal;
		public double _weight
		{
			get 
			{
				return _weightInternal;
			}
			set
			{
				_weightInternal = value;
				//Shipping cost is 100% dependent on weight. Recalculate it now.
				_shippingCost = 3.25m * (decimal)_weightInternal;
				//Retail price is partially dependent on shipping cost and thus on weight as well.  Make sure retail price stays up to date.
				_retailPrice = 1.7m * _wholesalePriceInternal * _shippingCost;
			}
		}
		
		private decimal _wholesalePriceInternal;
		public decimal _wholesalePrice
		{
			get
			{
				return _wholesalePriceInternal;
			}
			set
			{
				//Retail price is partially determined by wholesale price.  Make sure  retail price stays up to date.
				_retailPrice = 1.7m * _wholesalePriceInternal * _shippingCost;
			}
		}
		public int _quantity { get; set; }
		public decimal _shippingCost { get; private set; }
		public decimal _retailPrice { get; private set; }
		public Item(string name, double weight, decimal wholesalePrice, int quantity) : this()
		{
			_name = name;
			_weightInternal = weight;
			_wholesalePriceInternal = wholesalePrice;
			_quantity = quantity;
		}
		//More stuff
	}
