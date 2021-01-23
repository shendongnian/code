    public class ClassDataManagement
    {
        public DataTable BindDropDownList(string Sql, DropDownList DropDownList)
        {
            using (SqlConnection cn = new SqlConnection(@"Data Source=ABID-PC;Initial Catalog=_uniManagement;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(Sql, cn))
                {
                    using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            DropDownList.DataTextField = "Name";
                            DropDownList.DataValueField = "_Deptid";
                            DropDownList.DataSource = dt.DefaultView;
                            DropDownList.DataBind();
                            return dt;
                        }
                    }
                }
            }
        }
    
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ClassDataManagement dm = new ClassDataManagement();
        dm.BindDropDownList("select _Program.Name, _program._Deptid from _program,_Department "
            + "where _program._Deptid = _department._DeptId", DropDownListProgram);
    
    }
