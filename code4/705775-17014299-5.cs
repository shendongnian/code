    using  System.Data.SqlServerCe;
    private void updatedata() 
    {
         try     
         {
             if (imagename != "")    
             { 
                FileStream fs;
                byte[] picbyte;
                using(fs = new FileStream(@imagename, FileMode.Open, FileAccess.Read))
                {
                    //a byte array to read the image
                    picbyte = new byte[fs.Length];     
                    fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));  
                }
                string connstr = @"Data Source=.\TestImage.sdf;Persist Security Info=False;"
                string query = "insert into test_table(id_image,pic) " + 
                               "values(@id, @pic)";   
                 using(SqlCeConnection conn = new SqlCeConnection(connstr))
                 using(SqlCeCommand cmd = new SqlCeCommand(query, conn))
                 {
                    conn.Open();  
                    SqlCeParameter picparameter = new SqlCeParameter(); 
                    picparameter.SqlDbType = SqlDbType.Image;   
                    picparameter.ParameterName = "pic"; 
                    picparameter.Value = picbyte;                
                    cmd.Parameters.Add(picparameter);
                    SqlCeParameter idparameter = new SqlCeParameter(); 
                    idparameter.SqlDbType = SqlDbType.Int;   
                    idparameter.ParameterName = "id"; 
                    idparameter.Value = textBox1.Text;                
                    cmd.Parameters.Add(idparameter);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Image Added");  
                 }
            }   
         }
          .....
