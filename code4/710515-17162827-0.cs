     AutoCompleteStringCollection namesCollection1=new AutoCompleteStringCollection(); 
    string query1 = "select yarn_count from yarn";
    con.Open();
    SqlCommand cmb1 = new SqlCommand(query1, con);
    SqlDataReader dr1 = cmb1.ExecuteReader();
    if (dr1.HasRows == true)
    {
        while (dr1.Read())
        {
            namesCollection1.Add(dr1["yarn_count"].ToString());
    
        }
    }
    else
    {
        MessageBox.Show("Data not found");
    }
    
    con.Close();
    dr1.Close();
    int column1 = dataGridView1.CurrentCell.ColumnIndex;
    
    if (column1 == 9)
    {
    
        TextBox tb1 = e.Control as TextBox;
    
        if (tb1 != null)
        {
            tb1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb1.AutoCompleteCustomSource = namesCollection1;
            tb1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    
    }
    finally{con.Close();}
