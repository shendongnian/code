    SqlConnection cn;
    SqlCommand cmd;
    SqlDataAdapter da;
    int n=4;
    protected void Page_Load(object sender, EventArgs e)
    {
    cn = new SqlConnection(<Connection String>);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
          string query = "insert into temp values(@date))";
          cn.Open();
          cmd = new SqlCommand(query, cn);
          cmd.parameter.addwithvalue("@date",Convert.DateTime(TextBox1.Text));
          cmd.ExecuteNonQuery();
          cn.Close();
          Response.Write("Record inserted successfully");
        }
        catch (Exception ex)
        {
         Response.Write(ex.Message);
        }
    }
