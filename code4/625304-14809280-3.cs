    string SqlString = "SELECT Fält1, Fält2, Fält3 FROM Böcker WHERE Fält2 = ?";
    using (OleDbConnection conn = new OleDbConnection(ConnString))
    {
        using (OleDbDataAdapter da = new OleDbDataAdapter(SqlString, conn))
        {
            da.SelectCommand.Parameters.AddWithValue("Fält2", txt1.Text);
            DataTable dt = dataSet1.Tables["Böcker"];
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string text = string.Format("{0} {1}",
                    dt.Rows[0].Field<string>(0),
                    dt.Rows[0].Field<string>(1));
                lbl1.Text = text;
                lbl2.Text = dt.Rows[0].Field<string>(2);
            }
            else
            {
                lbl1.Text = "Boken hittades inte.";
            }
        }
    }
