    protected void btnSearch(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("MyConn");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM CustomerTable WHERE NumberOfCustomer = @NumberOfCustomer";
        cmd.Parameters.AddWithValue("NumberOfCustomer", TextBox1.Text);
        try
        {
            con.Open();
            sda.Fill(dt);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
