    public void addBook()
    {
      try
      {
        using (SqlConnection blah blah...)
        {
          myDatabaseConnection.Open();
          using (SqlCommand mySqlCommand1 = new SqlCommand("EXEC dbo.InsertBook", 
                 myDatabaseConnection))
          {
            mySqlCommand1.CommandType = CommandType.StoredProcedure;
            mySqlCommand1.Parameters.AddWithValue("@BookTitle", BookTitletextBox.Text);
            mySqlCommand1.Parameters.AddWithValue("@Copies",    int.Parse(textBox2.Text));
            mySqlCommand1.ExecuteNonQuery();
          }
        }
      }
      catch (Exception Ex)
      {
        MessageBox.Show(Ex.Message, "Exception");
      }
    }
    private void button1_Click(object sender, EventArgs e)
    {
      addBook();
    }
