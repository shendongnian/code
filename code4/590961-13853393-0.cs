        private class Product 
        {
            public string Name;
            public double Price;
            public string ToString()
            {
                return Name + " : " + Price.ToString() + "$";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>();
            names.Add("Jack");
            names.Add("John");
            names.Add("Nick");
            names.Add("Rock");
            List<Product> products = new List<Product>();
            products.Add(new Product { Name = "Laptop", Price = 1000 });
            products.Add(new Product { Name = "Tablet", Price = 750 });
            products.Add(new Product { Name = "Rock", Price = 1 });
            List<DateTime> dates = new List<DateTime>();
            dates.Add(DateTime.Now.AddDays(-1));
            dates.Add(DateTime.Now);
            dates.Add(DateTime.Now.AddDays(1));
            lblOutput.Text = "";
            foreach (string name in names)
            {
                if (name == txtSearch.Text)
                    lblOutput.Text += name + "[Name] ";
            }
            foreach (Product product in products)
            {
                if (product.Name == txtSearch.Text)
                    lblOutput.Text += product.ToString();
            }
            foreach (DateTime date in dates)
            {
                DateTime dt;
                if (DateTime.TryParse(txtSearch.Text, out dt))
                    if (date == dt)
                        lblOutput.Text = date.Date.ToShortDateString();
            }
        }
  
