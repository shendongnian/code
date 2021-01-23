    private void CreateLookupEdit()
    {
        ledMyControl = new LookUpEdit();
        ledMyControl.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key"));
        ledMyControl.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value"));
        this.Controls.Add(ledMyControl);
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("Test", "1");
        dic.Add("Test2", "2");
        dic.Add("Test3", "3");
        dic.Add("Test4", "4");
        dic.Add("Test5", "5");
        dic.Add("Test6", "6");
        dic.Add("Test7", "7");
        dic.Add("Test8", "8");
        dic.Add("Test9", "9");
        dic.Add("Test10", "10");
        ledMyControl.Properties.DisplayMember = "Value";
        ledMyControl.Properties.ValueMember = "Key";
        ledMyControl.Properties.DataSource = dic.ToList();
        ledMyControl.Properties.Columns[0].Visible = false;
    }
