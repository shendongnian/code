    string c_string = "server=.\\sqlexpress;database=Blue;trusted_connection=true";
    
        public static string ImageToShow; 
        private int NumOfFiles;
        //private string[] imgName;
       List<string> imgName= new List<string>();
    
    SqlConnection c = new SqlConnection(c_string);
            //SqlCommand cm = new SqlCommand(cmd,c);
    
    
       private void frmMain_Load(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(c_string);
    
            try
            {
                c.Open();
            }
            catch (SqlException ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                c.Close();
            }
            updateData();
        }
    
    private void updateData()
        {
    
            SqlConnection c = new SqlConnection(c_string);
    
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM FinalImages", c);
    
            DataTable dt = new DataTable();
            da.Fill(dt);
    
            NumOfFiles = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               // imgName[i] = Convert.ToString(dt.Rows[i]["FinalImageName"]);
               imgName.Add(Convert.ToString(dt.Rows[i]["FinalImageName"]));
            } 
        }
