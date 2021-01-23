    MySqlDataReader rdr = cmd.ExecuteReader();
    ArrayList temptbl = new ArrayList();
    while (rdr.Read()){
        temptbl.Add(new Class_NameValue(rdr.GetString(1), rdr.GetInt32(0)));
    }
    rdr.Close();
    cmb_items.DisplayMember = "NameMember";
    cmb_items.ValueMember = "IdMember";
    cmb_items.DataSource = new BindingSource(temptbl, null);
