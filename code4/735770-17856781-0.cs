    private void update_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            SqlConnection CN = new SqlConnection(constring);
    
            // this is a smaple query for update statement and update where id=@id
            string Query = "update test set name=@name,image=@img where id=@id ";
    
            CN.Open();
            cmd = new SqlCommand(Query, CN);
            cmd.Parameters.Add(new SqlParameter("@img", img));
            cmd.Parameters.Add(new SqlParameter("@id", txtid.Text));
            cmd.Parameters.Add(new SqlParameter("@name", txtname.Text));
            cmd.ExecuteNonQuery();
            CN.Close();
        }
