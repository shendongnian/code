    public partial class CheckBoxGridView : System.Web.UI.Page
    {
        public static T FindControl<T>(ControlCollection controls)
        {
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i] is T)
                    return (T)(object)controls[i];
            }
                return default(T);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable table = new DataTable();
                DataColumn col1 = new DataColumn("Field_1");
                DataColumn col11 = new DataColumn("Check_Box_1");
                DataColumn col12 = new DataColumn("Check_Box_2");
                DataColumn col13 = new DataColumn("Check_Box_3");
                col1.DataType = System.Type.GetType("System.String");
                col11.DataType = System.Type.GetType("System.Boolean");
                col12.DataType = System.Type.GetType("System.Boolean");
                col13.DataType = System.Type.GetType("System.Boolean");
                table.Columns.Add(col1);
                table.Columns.Add(col11);
                table.Columns.Add(col12);
                table.Columns.Add(col13);
                DataRow row = table.NewRow();
                row[col1] = "1";
                row[col11] = false;
                row[col12] = false;
                row[col13] = false;
                table.Rows.Add(row);
                DetailsView1.DataSource = table;
                DetailsView1.DataBind();
            }
            
        }
        protected void DetailsView1_ItemCommand(Object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "btnSelectAll")
            {
                foreach (DetailsViewRow row in DetailsView1.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        CheckBox cb = FindControl<CheckBox>(row.Cells[i].Controls);
                        if (cb != null)
                        {
                            cb.Checked = true;
                        }                        
                    }                    
                }
            }
        }
    }
