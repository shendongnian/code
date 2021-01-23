			var customers = new DataTable();
			customers.Columns.Add("ID", typeof(int));
			customers.Columns.Add("Name");
			customers.Rows.Add(1, "Tom");
			customers.Rows.Add(2, "Dick");
			customers.Rows.Add(3, "Harry");
			var purchases = new DataTable();
			purchases.Columns.Add("ID");
			purchases.Columns.Add("Description");
			purchases.Columns.Add("PurchaseID", typeof(int));
			purchases.Rows.Add(1, "Bike", 1);
			purchases.Rows.Add(2, "Holiday", 1);
			purchases.Rows.Add(3, "Bike", 2);
			purchases.Rows.Add(4, "Car", 3);
			var query = customers.AsEnumerable().Join(purchases.AsEnumerable(),
										cust => cust.Field<int>("ID"),
										purch => purch.Field<int>("PurchaseID"),
										(cust, purch) =>
										{
											var res = new List<object>();
											res.AddRange(cust.ItemArray);
											res.AddRange(purch.ItemArray);
											return res.ToArray();
										}
										);
