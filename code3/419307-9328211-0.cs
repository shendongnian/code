	public class CustomerItemListStruct { 
		public int ID { get; set; } 
		public string Name { get; set; } 
		public double Total { get; private set; }
		
		public double Rate { 
			get { return _rate;}
			set { _rate = value; UpdateTotal();} 
		} 
		private double _rate;
		
		public int Quantity {
			get { return _quantity;}
			set { _quantity = value; UpdateTotal();} 
		}
		private int _quantity;
		
		
		private void UpdateTotal()
		{
			Total = Quantity*Rate;
		}
	}
