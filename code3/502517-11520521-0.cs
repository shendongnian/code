	public class Order
	{
		public Order(int number)
		{
			Number = number;
		}
		public int Number { get; set; }
	}
	public class Item
	{
		// ... whatever your item is 
	}
	public class Program
	{
		static void Main()
		{
			var list = new List<Dictionary<Order, Item>>();
			var orders = new List<Order>()
			             	{
			             		new Order(1),
			             		new Order(2),
			             		new Order(3),
			             		new Order(4),
			             		new Order(5)
			             	};
			for (int i = 0; i < 10000; i++)
			{
				list.Add( new Dictionary<Order, Item>()
				          	{
				          		{orders[0], new Item()},
				          		{orders[1], new Item()},
				          		{orders[2], new Item()},
				          		{orders[3], new Item()},
				          		{orders[4], new Item()}
				          	});
			}
			// Now access items in order 
			var item = list[100][orders[1]];
			// now you can swap the orders: replace 2 and 4
			var temp = orders[1];
			orders[1] = orders[3];
			orders[3] = temp;
			var item = list[100][orders[1]]; // now points to previously 4th item!!
		}
	}
