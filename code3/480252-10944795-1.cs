    System.Windows.Forms.DateTimePicker dateTimePicker1 = new System.Windows.Forms.DateTimePicker();            
    dateTimePicker1.Name = "dateTimePicker1";
    dateTimePicker1.Size = new System.Drawing.Size(200, 20);            
    SqlConnection connection= new SqlConnection(@"Data Source=DATASOURCE;Initial Catalog=DBNAME;Persist Security Info=True;User ID=USERNAME;Password=PASSWORD"); 
    using (SqlCommand command = new SqlCommand("SELECT Top 1 colDate From tblTemp", connection)) 
    {     
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();     
        if (reader.Read())     
        {          
            DateTime dt=new DateTime();
            dt=DateTime.Now;
            bool b=DateTime.TryParse(reader["CreatedAt"].ToString(),out dt);
            dateTimePicker1.Value = dt;
        }
        connection.Close();
