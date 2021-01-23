    int id;
    if (int.TryParse(someTextBox.Text, out id))
    {
        int affectedRows = Update(id);
        if (affectedRows == 0)
        {
            MessageBox.Show("No rows were updated because the database doesn't contain a matching record");
        }
    }
    else
    {
        MessageBox.Show("You have entered an invalid ID");
    }
