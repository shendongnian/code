    private void btnSave_Click(object sender, EventArgs e)
    {
       try 
       {
          using (sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString))
          {
             sqlCon.Open();
             SqlCommand com = new SqlCommand("SELECT * FROM Employee", sqlCon);
             com.Parameters.AddWithValue(@empID, SqlDbType.Int).Value = int.Parse(txtID.Text);  // Add this line
             com.Parameters.AddWithValue(@empName, SqlDbType.NVarChar).Value = txtEmpName.Text; // Add this line too
             SqlDataReader read = new SqlDataReader();  // You also need to 'new' up your SqlDataReader.
             read = com.ExecuteReader(); 
             while (read.Read())
             {                     
                if (read.HasRows) 
                {
                SqlCommand update = new SqlCommand("UPDATE Employee SET EmpID = @empID, EmpName = @empName", sqlCon);
                update.ExecuteNonQuery();
                MessageBox.Show("Employee details updated!", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 else
                 {
                    SqlCommand comm = new SqlCommand("INSERT INTO Employee(EmpID, EmpName) VALUES (@empID, @empName)", sqlCon);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Employee details saved!", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
             }
        }
    
        catch(Exception ex) 
        {
            MessageBox.Show(ex.Message);
        }
         
        finally 
        {
            read.Close();
            sqlCon.Close();
        }
    }
