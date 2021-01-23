    SqlDataAdapter da = new SqlDataAdapter(SQLCmd1);
    DataTable dt = new DataTable();
    da.Fill(dt);
    employer_epf = Convert.ToDouble(dt.Rows[0][0].ToString());
    employer_admin = Convert.ToDouble(dt.Rows[1][0].ToString());
    employer_edli = Convert.ToDouble(dt.Rows[2][0].ToString());
    employer_admin_edli = Convert.ToDouble(dt.Rows[3][0].ToString());
    employer_esi = Convert.ToDouble(dt.Rows[4][0].ToString());
