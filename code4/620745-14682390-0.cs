    private void RefreshListView()
    {
    // clear ListView
    lvStudent.Items.Clear();
    List<string> myListHeader = new List<string>(new string[] { "ID", "Name", "Gender" });
    myListHeader.ForEach(name => lvStudent.Columns.Add(name));
    SqlConnection UGIcon = new SqlConnection();
    UGIcon.ConnectionString = "Data Source=xxx\\SQLEXPRESS;Initial Catalog=TestApplication;   Integrated Security=SSPI; User ID=xxx\\user;Password=xxx";
    UGIcon.Open();
    SqlCommand cmd = new SqlCommand("SELECT * FROM student", UGIcon);
    SqlDataReader dr = cmd.ExecuteReader();
    while (dr.Read()) {
        ListViewItem item = new ListViewItem(dr[0].ToString());
        item.SubItems.Add(dr[1].ToString());
        item.SubItems.Add(dr[2].ToString());
        lvStudent.Items.Add(item); }
    }
