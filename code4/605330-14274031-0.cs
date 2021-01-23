    protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=RGUNASEL-   DESK\\SQLEXPRESS;Initial Catalog=eLogbook;User ID=sa;Password=1234");
            connection.Open();
            SqlCommand cmd = new SqlCommand("eform2", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@lot_num", SqlDbType.VarChar, 50)).Value = TextBox8.Text;
            cmd.Parameters.Add(new SqlParameter("@location", SqlDbType.VarChar, 50)).Value = TextBox9.Text;
            cmd.Parameters.Add(new SqlParameter("@total_in", SqlDbType.VarChar)).Value = TextBox10.Text;
            cmd.Parameters.Add(new SqlParameter("@first_test", SqlDbType.VarChar, 50)).Value = TextBox11.Text;
            cmd.Parameters.Add(new SqlParameter("@second_test", SqlDbType.VarChar)).Value = TextBox12.Text;
            cmd.Parameters.Add(new SqlParameter("@third_test", SqlDbType.VarChar, 50)).Value = TextBox13.Text;
            cmd.Parameters.Add(new SqlParameter("@total_out", SqlDbType.VarChar, 50)).Value = TextBox14.Text;
            cmd.Parameters.Add(new SqlParameter("@lot_status", SqlDbType.VarChar, 50)).Value = TextBox17.Text;
            cmd.Parameters.Add(new SqlParameter("@remark", SqlDbType.VarChar, 50)).Value = TextBox16.Text;
            cmd.ExecuteNonQuery();
            //Response.Write("Submitted!");
            //Code to bind gridview
            Dataset dst=yourFunctionToGetRequiredTableRows();
            yourGridView.DataSource=dst;
            yourGridView.Databind();
        }
