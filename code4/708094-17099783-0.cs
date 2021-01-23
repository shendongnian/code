    db.Dispose();
    db = new UniformDataContainer();
    int id = Convert.ToInt32(textBox1.Text);
    db.Items.Where(i => i.TransactionId == id).Load();
    bs.DataSource = db.Items.Local.ToBindingList();
