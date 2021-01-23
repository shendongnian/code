    private void button1_Click(object sender, EventArgs e)
    {
        string strconn = "<connection string";
    
        using (SqlConnection conn = new SqlConnection(strconn))
        {
            bool readerHasRows = false; // <-- Initialize bool here for later use
            DateTime Dt_Time = DateTime.Now;
            string Barcode = textBox1.Text;
            string commandQuery = "SELECT Barcode FROM table3 WHERE Barcode = @Barcode";
            using(SqlCommand cmd = new SqlCommand(commandQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Barcode", textBox1.Text);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    // bool initialized above is set here
                    readerHasRows = (reader != null && reader.HasRows);
                }
            }
        
            if (readerHasRows)
            {
                //email exists in db do something
                MessageBox.Show("Barcode Already Exists!!");
            }
            else
            {
                //Same as above
                string strquery = "INSERT INTO table3 VALUES (@Barcode, @DtTime)"; // '{0}','{1}')", Barcode, Dt_Time);
                using (SqlCommand cmd = new SqlCommand(strquery, conn))
                {
                    cmd.Parameters.AddWithValue("Barcode", Barcode);
                    cmd.Parameters.AddWithValue("DtTime", Dt_Time);
                    int count = cmd.ExecuteNonQuery(); // this already the number of affected rows by itself
                    // NOTE: '\n' doesn't really work to output a line break. 
                    // Environment.NewLine should be used.
                    MessageBox.Show("Barcode:" + Barcode + Environment.NewLine + "Time" + Dt_Time);
                }
            // code probably goes on ...
        } // end of using(SqlConnection...
    } // end of method
