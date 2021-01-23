    Ctx.MyEntitySet.Load();
    BindingSource yourBS = new BindingSource();
    yourBS.DataSource = Ctx.MyEntitySet.Local.ToBindingList();
    
    dataGridView1.DataSource = yourBS;
    dataGridView1.Columns["Id"].Visible = false;
    dataGridView1.Columns["UnwantedCol1"].Visible = false;
    dataGridView1.Columns["UnwantedCol2"].Visible = false;
    dataGridView1.Columns["UnwantedCol3"].Visible = false;
