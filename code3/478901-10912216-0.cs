    public class CustomCar
	{
		private string name;
		private string plateno;
		private double cost;
		private CarCustomer _customer = new CarCustomer();
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public double Cost
		{
			get { return cost; }
			set { cost = value; }
		}
	
	
		public string PlateNo
		{
			get { return plateno; }
			set { plateno = value; }
		}
	
	
	
		public CarCustomer Customer
		{
			get { return _customer; }
			set { _customer = value; }
		}
		
		public CustomCar()
		{
			Console.WriteLine("I am in custom car");
		}
	
	
	
		public CustomCar(string name, string pno, double c, string customerName, double n, double bc)
		{
			this.Name = name;
			this.PlateNo = pno;
			this.Cost = c;
			this.Customer.Name1 = customerName;
			this.Customer.Nic1 = n;
			this.Customer.BargainCost = bc;
			this.Customer.Car = this;
		}
	
		public double finalCost()
		{
			if (this.Customer.BargainCost < 10000)
			{
				double FinalCost = (this.Cost - this.Customer.BargainCost);
				return FinalCost;
			}
			else
			{
				return this.Cost;
			}
	
		}
	
		public void show()
		{
			Console.WriteLine(this.name + this.PlateNo + this.Customer.Name1 + this.Customer.Nic1);
		}
	}
			
		public class CarCustomer
		{
			private string name1;
			private double Nic;
			private double bargainCost;
			private CustomCar customer;
	
			public double BargainCost
			{
				get { return bargainCost; }
				set { bargainCost = value; }
			}
	
			public double Nic1
			{
				get { return Nic; }
				set { Nic = value; }
			}		
			
	
			public string Name1
			{
				get { return name1; }
				set { name1 = value; }
			}
			
			public CustomCar Car
			{
				get{return customer;}
				set{customer = value;}
			}
	
			public CarCustomer()
			{
				Console.WriteLine("I have a customer");
			}
	
			public CarCustomer(string n1, double i1, double bc)
			{
				this.Name1 = n1;
				this.Nic = i1;
				this.BargainCost = bc;					
			}
	
			public void showCustomer()
			{
				Console.WriteLine("Customer name:   " + Name1);
				Console.WriteLine("Customer NIC:    " + Nic1);
			}
		}
	
	
