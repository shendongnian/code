    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Configuration;
    public bool IsDateInRange(string date, string employeeId)
    {
        DateTime dateToCompare = DateTime.MinValue;
        bool isInRange = false;
        if (!String.IsNullOrEmpty(date) && !String.IsNullOrEmpty(employeeId) &&
            DateTime.TryParse(date, out dateToCompare))
        {
            DataTable table = new DataTable();
            string connectionString = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT TOP 1 * FROM EmployeeDates WHERE EMPNAME = @EmpName";
                    command.Parameters.AddWithValue("@EmpName", employeeId);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                    DateTime fomDate = (DateTime)table.Rows[0]["FRMDATE"];
                    DateTime toDate = (DateTime)table.Rows[0]["TODATE"];
                    //DateTime.Ticks converts a date into long
                    //Now you can simply compare whether the input date falls between the required range
                    if (dateToCompare.Ticks >= fomDate.Ticks && dateToCompare.Ticks <= toDate.Ticks)
                    {
                        isInRange = true;
                    }
                    connection.Close();
                }
            }
        }
        return isInRange;
    }
