    public partial class Default : System.Web.UI.Page
    {
        private readonly string connection_string = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindData();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            var itemsToDelete = new ListItemCollection(); 
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                    itemsToDelete.Add(item);
            }
            foreach (ListItem item in itemsToDelete)
            {
                //Assuming your id column is Rollno
                DeleteFromDB(item.Value);
                CheckBoxList1.Items.Remove(item);
            }
        }
        private void BindData()
        {
            using (var con = new SqlConnection(connection_string))
            {
                con.Open();
                using (var adapter = new SqlDataAdapter("SELECT * FROM stud_table", con))
                {
                    var ds = new DataSet();
                    adapter.Fill(ds);
                    CheckBoxList1.DataSource = ds;
                    CheckBoxList1.DataTextField = "Name";
                    CheckBoxList1.DataValueField = "Rollno";
                    CheckBoxList1.DataBind();
                    con.Close();
                }
            }
        }
        private void DeleteFromDB(string rollNo)
        {
            int id = 0;
            if (Int32.TryParse(rollNo, out id))
            {
                using (var con = new SqlConnection(connection_string))
                {
                    con.Open();
                    string commandText = String.Format("DELETE FROM stud_table WHERE Rollno={0}", id);
                    using (var command = new SqlCommand(commandText, con))
                    {
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
    }
