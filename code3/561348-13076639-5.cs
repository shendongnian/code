    public void Bind_GridView1() {
            DataTable commentsTable = null;
            commentsTable = new DataTable("Comments");
            using (SqlDataReader reader = studentManager.getCommentsFromDB())
            {
                commentsTable.Load(reader);
                GridView1.DataSource = commentsTable;
                GridView1.DataBind();
            }
    }
