        using (InventoryEntities c = new InventoryEntities(Properties.Settings.Default.Connection))
        {
            comboBox1.DataSource    = c.Customers;
            comboBox1.ValueMember   = "id";
            comboBox1.DisplayMember = "name";
        }
