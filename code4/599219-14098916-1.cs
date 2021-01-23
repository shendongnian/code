    List<string> strArr = new List<string>();
    strArr.Items.Clear();
    for(int intSubCount = 0; intSubCount < dtTable2.Rows.Count;intSubCount++)
    {
       if(MyComboBox.Text.Equals(dtTable2.Rows[intSubCount]["modelid"].ToString()))
       {
           strArr.Add(dtTable2.Rows[intSubCount]["name"].ToString());
       }
    }
    foreach(string str in strArr)
    {
        if (str == comboBox4.SelectedItem.ToString())
        {   
           comboBox3.DataSource = table1BindingSource;
           comboBox3.ValueMember = str;
           comboBox3.DisplayMember = str;
        }
    }
    
