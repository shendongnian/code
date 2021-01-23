        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlCommand objCmd = new SqlCommand("SELECT DEPTNO, DNAME FROM DEPT", objConn);
                objConn.Open();
                RadBut_Answer.DataSource = objCmd.ExecuteReader();
                RadBut_Answer.DataTextField = "DNAME";
                RadBut_Answer.DataValueField = "DEPTNO";
                RadBut_Answer.DataBind();
                objConn.Close();
            }
        }
