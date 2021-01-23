       if (cpd_recipientsBindingSource.Current == null) return;
			using (var con = new cpdEntities())
			{
				var p = new Customer()
				{
					CustomerId = ((cpd_recipients)cpd_recipientsBindingSource.Current).Id,
					CustomerIdNo = IdNoTextBox.Text,
					CustomerName = CustomerNameTextBox.Text
				};
				var cus = new Customer();
				if (p.CustomerId > 0)
					cus = con.Customers.First(c => c.CustomerId == p.CustomerId);
				cus.CustomerId = p.CustomerId;
				cus.CustomerIdNo = p.CustomerIdNo;
				cus.CustomerName = p.CustomerName;
				if (p.CustomerId == 0)
					con.Customers.AddObject(cus);
				con.SaveChanges();
				int i = cus.CustomerId;//SCOPE_IDENTITY
			}
		}
 
