    private void button1_Click(object sender, EventArgs e)
        {
            string EF = textBox1.Text;
            
            try{
                //SqlDataAdapter adapter = SetupDataAdapter("SELECT * FROM id_declarant");
         SqlCommand comm = new SqlCommand();
         string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=declaration;Integrated Security=True";
          comm.Connection=new SqlConnection(connectionString);
                String sql = @"SELECT * 
                      FROM id_declarant,declarant
                     WHERE (declarant.Nom_pren_RS='" + EF + "') and (id_declarant.mat_fisc=declarant.mat_fisc)  "; 
         comm.CommandText = sql;
      comm.Connection.Open();
                 SqlDataReader reader = comm.ExecuteReader();
                 DataTable schemaTable = reader.GetSchemaTable();
                 foreach (DataRow row in schemaTable.Rows)
                 {
                     foreach (DataColumn column in schemaTable.Columns)
                     {
                         System.IO.File.WriteAllText(@"C:\Users\Manuela\Documents\GL4\WriteLines.txt", column.ColumnName + column.DataType );
                        
                     }
                 }
