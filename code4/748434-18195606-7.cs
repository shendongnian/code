    public void addBook()
    {
      try
      {
        int Copies    = int.Parse(textBox2.Text);
        string BTitle = BookTitletextBox.Text
        using (SqlConnection conn = new SqlConnection ...blah blah...)
        {
          conn.Open();
          using (SqlCommand cmd = new SqlCommand("EXEC dbo.InsertBook", conn))
          {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookTitle", BTitle);
            cmd.Parameters.AddWithValue("@Copies",    Copies);
            cmd.ExecuteNonQuery();
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
