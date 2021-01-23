      private void button1_Click(object sender, EventArgs e)
            {                  
    SqlConnection conn = new SqlConnection();
    conn.Open();
    
    SqlCommand comm = new SqlCommand();
    comm.Connection = conn;
    
    string sr = null;
    string name = null;
    string email = null;
    string tel_no = null;
    
    
    for (int i = 0; i <= this.DataGridView1.Rows.Count; i++) {
    sr == this.DataGridView1.Rows(i).Cells(0).Value.ToString()
    name == this.DataGridView1.Rows(i).Cells(1).Value.ToString()
    email == this.DataGridView1.Rows(i).Cells(2).Value.ToString()
    tel_no == this.DataGridView1.Rows(i).Cells(3).Value.ToString()
    
     comm.CommandText = "insert into mytable(name,age) values('" & name & "','" & age& "')"
       comm.ExecuteNonQuery()
    
    conn.Close()
    
    
    }
        
    }
