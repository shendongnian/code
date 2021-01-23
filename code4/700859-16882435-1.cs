    MySqlCommand cmmd = new MySqlCommand("SELECT Pain FROM members WHERE username='" + textBox2.Text + "';");
    cmmd.Connection = con;
    con.Open();
    var res = cmmd.ExecuteScalar();
    
    int pain;
    if (int.TryParse(res , out pain))
    {
      if(pain==1){
          MessageBox.Show("NO");
       }else{
          MessageBox.Show("YES");  
       }               
    }
    read.Dispose();
    cmmd.Dispose();
