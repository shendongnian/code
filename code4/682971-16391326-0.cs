    conn.Open();
    string qry = "UPDATE clickStream SET clickCount = (clickCount + 1) WHERE linkName = @linkName";
    SqlCommand cmd = new SqlCommand(qry, conn);
    // Use a SqlParameter to correct an error in the posted code and do so safely.
    cmd.Parameters.Add(new SqlParameter("@linkName", mainServiceButton)); // TBD: mainServiceButton vs. mainServiceButton.Text etcetera
    try
    {
        cmd.ExecuteNonQuery(); // not ExecuteScalar()
    }
    catch (SqlException sex)
    {
        MessageBox.Show(sex.ToString());
    }
    conn.Close();
