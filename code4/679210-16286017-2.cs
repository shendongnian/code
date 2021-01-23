    private void button2_Click(object sender, EventArgs e) //puts selectedproduct to the cart
    {
        Product p = listBox1.SelectedItem as Product;
        int q = (int)numericUpDown1.Value;
        if (p == null || q == 0 || p.Quantity < q)
            return;
        foreach (Product item in listBox2.Items)
        {
            if (item.ID == p.ID)
            {
                return;
            }
        }
        listBox2.Items.Add(new OrderItem { Product = p, Quantity = q, TotalPrice = p.Price * q });
        p.Quantity -= q;
    }
    private void button1_Click(object sender, EventArgs e) 
    {
        Order o = new Order() { account = Variables.Currentuser, Items = new List<Order>() };
        foreach (OrderItem item in listBox2.Items)
        {
            o.Items.Add(item);
        }
        Variables.Db.orders.Add(o);
        Variables.Db.SaveChanges(); //Variables.Db is my CodeFirst Database
    }
