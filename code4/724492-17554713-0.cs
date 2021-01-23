    private void button1_Click(object sender, EventArgs e)
    {
        byte[] bytes = File.ReadAllBytes(@"C:\pdf.pdf");
        SqlParameter fileP = new SqlParameter("@file", SqlDbType.VarBinary);
        fileP.Value = bytes;
        SqlCommand myCommand = new SqlCommand();
        myCommand.Parameters.Add(fileP);
        SqlConnection conn = new SqlConnection(@"Data Source=CoastAppsDev\SQL2008;Initial Catalog=CSharpWinForms;Integrated Security=True;");
        conn.Open();
        myCommand.Connection = conn;
        myCommand.CommandText = "spPdfInsert";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.ExecuteNonQuery();
        conn.Close();
    }
