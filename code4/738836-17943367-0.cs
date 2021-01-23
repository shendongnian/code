    ....
    ....
    ....
    using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT * FROM LoanPortfolio where custID like 'OH00002'", conn))
                    {
                        DataTable dTable = new DataTable();
                        dAd.Fill(dTable);
                        conn.Close();
                        return dTable;
                    }
