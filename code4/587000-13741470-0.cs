    var table = new DataTable();
    table.Load(reader);
    var bs = new BindingSource(table, null);
    lblDesc.DataBindings.Add("Text", bs, "emp_username"),
    btnNext.Click += ()
    {
        bs.MoveNext();
    };
    btnPrev.Click += ()
    {
        bs.MovePrevious();
    };
