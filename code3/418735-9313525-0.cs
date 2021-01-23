    public void AddItems(DataTable dt, string textField, string valueField)
    {
        ClearAll();
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            chkList.Items.Add(dr[textField].ToString());
            chkList.Items[i].Value = dr[valueField].ToString(); 
            i++;               
        }
    }
