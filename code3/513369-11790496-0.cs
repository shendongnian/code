    DataTable dt = ds.Tables[0];
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        string id = dt.Rows[i][0].ToString();
        string value = dt.Rows[i][1].ToString();
       
        ListItem li=new ListItem();
        li.Text = id;
        li.Value = value;
        ListBox1.Items.Add(li);
        
    }
