    private void button1_Click(object sender, EventArgs e)
    {
        List<Category> lstCategory = Manager.GetCategories();
        int i = 5, j = 5;
        foreach (Category cat in lstCategory)
        {
            Label label = new Label();
            label.Text = cat.Name;
            Panel panel = new Panel();
            panel.Tag = cat;
            panel.Controls.Add(label);
            //if you already have panel created for categories, then start from here..
            panel.Click += ((s, r) =>
            {
                List<Product> lstProduct = Manager.GetProducts((Category)panel.Tag);
                int x = 5, y = 5;
                foreach (Product product in lstProduct)
                {
                    var pnl = new Panel();
                    pnl.BorderStyle = BorderStyle.Fixed3D;
                    pnl.Size = new Size(15, 15);
                    pnl.Location = new Point(20 + x, 20 + y); //position it properly.
                    this.Controls.Add(pnl);
                    pnl.Tag = product;
                    Label lbl = new Label();
                    lbl.Text = product.Name;
                    panel.Controls.Add(lbl);
                    pnl.Click += ((p, q) =>
                    {
                       dataGridView1.Rows.Add(//according to pnl.Tag values
                    });
                }
            });
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Size = new Size(15, 15);
            panel.Location = new Point(20 + i, 20 + j); //position it properly.
            this.Controls.Add(panel);
        }
    }
