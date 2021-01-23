        DataTable m_table = null;
        public DataTable table
        {
            get
            {
                if (ViewState["m_table"] != null)
                    return (DataTable)ViewState["m_table"];
                else
                    return null;
            }
            set
            {
                ViewState["m_table"] = value;
            }
        }
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
                table = new DataTable();
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
            if (e.CommandName == "btnSave")
            {
                int j = 0;
                foreach (DetailsViewRow row in DetailsView1.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        TextBox tb = FindControl<TextBox>(row.Cells[i].Controls);
                        if (tb != null)
                        {
                            table.Rows[0][j] = tb.Text;
                        }
                        CheckBox cb = FindControl<CheckBox>(row.Cells[i].Controls);
                        if (cb != null)
                        {
                            table.Rows[0][j] = cb.Checked;
                        }
                    }
                    j++;
                }
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                DetailsView1.DataSource = table;
                DetailsView1.DataBind();
            }
            if (e.CommandName == "btnEdit")
            {
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                DetailsView1.DataSource = table;
                DetailsView1.DataBind();
            }
            if (e.CommandName == "btnCancel")
            {
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                DetailsView1.DataSource = table;
                DetailsView1.DataBind();
            }
        }
