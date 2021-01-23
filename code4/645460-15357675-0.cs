    private void btnUpdate_Click(object sender, EventArgs e) {
        string code = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString().ToUpper();
        string currency_Name = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString().ToUpper();
        string boolBase = dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        string local_per_Base = dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        string base_per_Local = dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        string select_qry = "Select * from centraldb.dbo.CPDM0020 Where Code = '" + Code + "'";
       if(IsExistRecord(select_qry))
        {
        string update_qry = Update centraldb.dbo.CPDM0020 set Code,Currency_Name='" + currency_Name + "',Base='" + boolBase + "',Local_per_Base,Base_per_Local='" + base_per_Local + "' where code='" + code +"'";
        if (this.ExecuteSql(update_qry)) {
            MessageBox.Show("Record Updated Successfully.");
        } else {
    
            MessageBox.Show("Update Failed");
        }
        }
    }
        //code taken from  Mohammad abumazen 
     public bool IsExistRecord(string Query)
     {
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand(Query, Connection);
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DA.Fill(DT);
            if (DT.Rows.Count > 0)
                return true;
            else
                return false;
        }
