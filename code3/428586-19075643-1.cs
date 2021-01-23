    String val = TextBox2.Text;
    String sql = "SELECT QLEVELNAME FROM Qual_Levels WHERE QUALID=@QUALID";
    SqlCommand cmd = new SqlCommand(sql, new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentDBConnString"].ConnectionString));
    SqlDataAdapter da = new SqlDataAdapter(sql, cmd.Connection);
    DataSet ds = new DataSet();
    cmd.Parameters.Add(new SqlParameter("@QUALID", val));
   
    da.SelectCommand = cmd;
    cmd.Connection.Open();
       
    da.Fill(ds, "Qual_Levels");
    SelectionGrid.DataSource = ds;
    SelectionGrid.DataBind();
    ds.Dispose();
    da.Dispose();
    cmd.Connection.Close();
    cmd.Connection.Dispose();
