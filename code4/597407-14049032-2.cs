        List<Detail> list = new List<Detail>();
        for (int i = 0; i < 10; i++)
        {
             Detail d = new Detail();
             d.Foo = "test";
             list.Add(d);
        }
 
        this.dgv.DataSource = list;
        this.dgv.Columns[0].Visible = false;
        DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
        dgvc.HeaderText = "列标题";
        dgvc.DataPropertyName = "foo";
        this.dgv.Columns.Add(dgvc);
