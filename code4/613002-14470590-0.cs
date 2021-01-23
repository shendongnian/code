    public partial class WebForm4 : System.Web.UI.Page {
    SqlConnection sqlcon = new SqlConnection("Data Source=Local-host;Initial 
                                          Catalog=HRM_Login;Integrated Security=True");
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter sqladp = new SqlDataAdapter();
            DataSet ds = new DataSet();
    
        protected void Button1_Click(object sender, EventArgs e)
                {
                    Label2.Visible = true;
                    GridView1.Visible = true;
        
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandText = "GetStudentName";
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.Add(new SqlParameter("@Studentid", SqlDbType.Int)).Value 
                                              = Int32.Parse(txt_studentid.Text);
                    sqladp.SelectCommand = sqlcmd;
                    sqladp.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
        }
