    private void displayOrdersToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (NorthWindDataContext db = new NorthWindDataContext())
        {
            var query =
                from o in db.Orders.
                    Where(item => item.ID == dataGridView1.SelectedValue)
                select new
                {
                    o.ShipName <----problem  here :(
                };
            dataGridView2.DataSource = query;
        }
    }
