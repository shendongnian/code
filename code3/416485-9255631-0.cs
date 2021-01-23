    protected void updateButton_Click(object sender, EventArgs e)
    {
        //COMMAND DEFINED
        string deleteCommand = "DELETE FROM employee_courses where employeeID=@employeeID";
    
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            //COMMAND CREATED
            using (SqlCommand cmd = new SqlCommand(deleteCommand, conn))
            {
                //COMMAND EXECUTED, BUT @employeeID NOT SET ANYWHERE
                cmd.ExecuteNonQuery();
            }
        }
