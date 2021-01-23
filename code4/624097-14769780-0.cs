    LookUpEdit lookupEdit = new LookUpEdit();
    Dictionary<string,string>  dic = new Dictionary<string,string>();
    dic["1"] = "jedan";
    dic["2"] = "dva";
    lookupEdit.Properties.ValueMember = "Key";
    lookupEdit.Properties.DisplayMember = "Value";
    lookupEdit.Properties.DataSource = dic.ToList();
    
    // if you want to hide Key column
    LookUpColumnInfo keyColumnInfo = new LookUpColumnInfo("Key");
    keyColumnInfo.Visible = false;
    lookupEdit.Properties.Columns.Add(keyColumnInfo);
    lookupEdit.Properties.Columns.Add(new LookUpColumnInfo("Value"));
		
    // set selected item
    lookupEdit.EditValue = "2";
