    private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
    {
        Dictionary<string, int> d = db.BRAND.ToDictionary(c => c.NAME, c => c.ID);
        comboBox2.DataSource = (from c in db.ITEM
                                where c.BRAND_ID == d[comboBox1.Text]
                                select c.NAME).ToList();
    }
