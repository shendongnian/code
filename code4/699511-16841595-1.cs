    if (listBox1.Items.Count > 0)
    {
        SqlCommand cmd = new SqlCommand("UPDATE Table2 SET kat_aitisis=@kat WHERE aitisi_ID=@id";, cn);
        string kat1 = "Μοριοδοτηθείσα";
        cmd.Parameters.AddWithValue("@kat", kat1);
        cmd.Parameters.AddWithValue("@id", 0);
        SqlCommand cmd1 = new SqlCommand("select * from Table2 WHERE aitisi_ID=@id", cn);
        cmd1.Parameters.AddWithValue("@id", 0);
        SqlCommand cmd2 = new SqlCommand("INSERT INTO .......",cn);
        cmd2.Parameters.AddWithValue(.....);
        ... add the remainung cmd2.Parameters...... 
        for (int i = 0; i < listBox1.Items.Count; i++)
        {
             cn.Open();
             cmd.Parameters["@id"].Value = Convert.ToInt32(listBox1.Items[i]);
             cmd.ExecuteNonQuery();
             dr = cmd1.ExecuteReader();
             cmd1.Parameters["@id"].Value = Convert.ToInt32(listBox1.Items[i]);
             while (dr.Read())
             {
                 ..set the cmd2 parameters values ...
                 cmd2.ExecuteNonQuery();
             }
             MessageBox.Show("blahblah.");
        }
