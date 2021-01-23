    DataTable s = produseTableAdapter.GetData();
    DataTable t = produse_magazinTableAdapter.GetData();
    s.Merge(t);
    BindingSource bs = new BindingSource();
    bs.DataSource = s;
    bs.Filter = "YourColumnName LIKE '%consumabile%'";
    //OR
    bs.Filter = "yourColumnName = 'consumabile'";
