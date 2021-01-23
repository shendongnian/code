    DataTable _tbValues;
    private void Form1_Load(object sender, EventArgs e)
    {
        _tbValues = new DataTable();
        string[] cells = new string[89];
        for (int i = 0; i < 89; i++)
        {
            _tbValues.Columns.Add(String.Format("Box{0}", i));
            var tb = new TextBox();
            tb.Name = String.Format("Box{0}", i);
            tb.DataBindings.Add("Text", _tbValues, String.Format("{0}", tb.Name));
            tb.Top = i * 20;
            this.Controls.Add(tb);
        }
        _tbValues.Rows.Add(cells);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        _tbValues.Rows[0].ItemArray = Enumerable
            .Repeat(DateTime.Now as object, _tbValues.Columns.Count)
            .ToArray();
        _tbValues.AcceptChanges();
    }
