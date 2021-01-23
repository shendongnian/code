    //Global Variable
    BindingList<CPatient> bind = new BindingList<CPatient>();
    BindingSource bs = new BindingSource();
    private void Form1_Load(object sender, EventArgs e)
    {
       
        bind.Add(new CPatient { Id = 1, IdNo = "1235", Name = "test" });
        bind.Add(new CPatient { Id = 2, IdNo = "6789", Name = "let" });
        bind.Add(new CPatient { Id = 3, IdNo = "1123", Name = "go" });
        bind.Add(new CPatient { Id = 4, IdNo = "4444", Name = "why" });
        bind.Add(new CPatient { Id = 5, IdNo = "5555", Name = "not" });
        bs.DataSource = bind;
        dataGridView1.DataSource = bs;
    }
