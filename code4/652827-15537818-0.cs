    const string ConnectionString = "Initial Catalog=Northwind;Data Source=localhost;Integrated Security=SSPI;";
    const string GetLabelText = "select labeltext from myLabelTextTable where id={0}";
    const string DefaultLabelText = "-undefined-";
        
    public void UpdateLabel(Label myLabel, int labelTextId)
    {
        string labelText;
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            using (SqlCommand command = new System.Data.SqlClient.SqlCommand(string.Format(GetLabelText,labelTextId), connection))
            {
                labelText = (command.ExecuteScalar() ?? DefaultLabelText).ToString();
            }
            connection.Close();
        }
        myLabel.Text = labelText;
    }
