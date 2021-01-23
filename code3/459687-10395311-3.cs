    private void RespondingToTcpRequest()
    {
        using (var connection = new SqlConnection(""))
        using (var command = new SqlCommand("", connection))
        {
             connection.Open();
    
             using (var reader = command.ExecuteReader())
             {
                 // No locks or sharing issues here!
             }
        }
    }
