    public void SomeMethod()
    {
        var connString = "whatever"; // could also be something like Textbox1.Text
        using (var connection = new SqlConnection(connString))
        {
            var context = new DataContext(connection);
        }
    }
