    private void updatedata()
    {
 
        //use filestream object to read the image.
 
        //read to the full length of image to a byte array.
 
        //add this byte as an oracle parameter and insert it into database.
 
        try
        {
 
            //proceed only when the image has a valid path
 
            if (imagename != "")
            {
 
                FileStream fs;
 
                fs = new FileStream(@imagename, FileMode.Open, FileAccess.Read);
 
                //a byte array to read the image
 
                byte[] picbyte = new byte[fs.Length];
 
                fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
 
                fs.Close();
 
                //open the database using odp.net and insert the data
 
                string connstr = @"Data Source=.;Initial Catalog=TestImage;
                Persist Security Info=True;User ID=sa";
 
                SqlConnection conn = new SqlConnection(connstr);
 
                conn.Open();
 
                string query;
 
                query = "insert into test_table(id_image,pic) values(" + 
                textBox1.Text + "," + " @pic)";
 
                SqlParameter picparameter = new SqlParameter();
 
                picparameter.SqlDbType = SqlDbType.Image;
 
                picparameter.ParameterName = "pic";
 
                picparameter.Value = picbyte;
 
                SqlCommand cmd = new SqlCommand(query, conn);
 
                cmd.Parameters.Add(picparameter);
 
                cmd.ExecuteNonQuery();
 
                MessageBox.Show("Image Added");
 
                cmd.Dispose();
 
                conn.Close();
 
                conn.Dispose();
 
                Connection();
 
            }
 
        }
 
        catch (Exception ex)
        {
 
            MessageBox.Show(ex.Message);
 
        }
 
    }
