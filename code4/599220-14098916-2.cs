    List<string> strArr = new List<string>();
    strArr.Items.Clear();
    for(int intSubCount = 0; intSubCount < dtTable2.Rows.Count;intSubCount++)
    {
       if(MyComboBox.Text.Equals(dtTable2.Rows[intSubCount]["modelid"].ToString()))
       {
           strArr.Add(dtTable2.Rows[intSubCount]["name"].ToString());
       }
    }
    //
    comboBox3.DataSource = strArr;
