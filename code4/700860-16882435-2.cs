    MySqlCommand cmmd = new MySqlCommand("SELECT Pain FROM members WHERE username='" + textBox2.Text + "';");
    cmmd.Connection = con;
    con.Open();
    int? pain = (int?)cmmd.ExecuteScalar();
    
    if (pain.HasValue)
    {
      if(pain==1){
          MessageBox.Show("NO");
       }else{
          MessageBox.Show("YES");  
       }               
    }
    read.Dispose();
    cmmd.Dispose();
