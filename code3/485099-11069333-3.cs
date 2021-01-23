        private void Form4_Load(object sender, EventArgs e)
        {
            List<Products> productList = new List<Products>()
            {
                new Products{ProductName = "P1", ProductPrice = 56, Category = "c1"},
                new Products{ProductName = "P2", ProductPrice = 36, Category = "c1"}    
            };
            //var p = from s in productList select s;
            dataGridView1.DataSource = productList;
            //dataGridView1.DataMember = p.ToString();
        }
