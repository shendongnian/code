            **comboBox2.DataSource = null;**
            if (ComboBox1.Text == "Customers")
            {
                var qry = (from u in dc.Customers
                           select new { u.CustomerID, u.CompanyName }).ToList();
                comboBox2.ValueMember = "CustomerID";
                comboBox2.DisplayMember = "CompanyName";
                comboBox2.DataSource = qry;
            }
            if (ComboBox1.Text == "Suppliers")
            {
                var qry = (from u in dc.Suppliers
                           select new { u.SupplierID, u.CompanyName }).ToList();
                comboBox2.ValueMember = "SupplierID";
                comboBox2.DisplayMember = "CompanyName";
                comboBox2.DataSource = qry;
            }
