    SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Yourdatabase;Integrated Security=SSPI");
    int res = 0;
    try
    {
    conn.Open();
    SqlCommand cmd = new SqlCommand("update docs SET locked=0 WHERE ID= @id");
    cmd.Parameters.AddWithValue("@id", txtid.text);
    res = cmd.ExecuteNonQuery();
    }catch(Exception err){ 
    MessageBox.Show(err.getMessage());
    }finally{
    conn.Close();
    }
