    public partial class GridTest : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CreateGridColumns();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindGrid();
        }
        private void CreateGridColumns()
        {
            var tblDomain = GetDomains();
            // Create dynamic TemplateFields
            foreach (DataRow row in tblDomain.Rows)
            {
                String domainName = row.Field<String>("DomainName");
                TemplateField field = new TemplateField();
                //Initalize the DataField value.
                field.ItemTemplate = new GridViewCheckBoxTemplate(ListItemType.Item, domaninName);
                field.HeaderText = domainName;
                //Add the newly created field to the GridView.
                GridView1.Columns.Add(field);
            }
        }
        private DataTable GetDomains()
        {
            var tblDomain = new DataTable();
            tblDomain.Columns.Add("DomainID", typeof(int));
            tblDomain.Columns.Add("DomainName");
            tblDomain.Rows.Add(1, "Google.com");
            tblDomain.Rows.Add(2, "Yahoo.com");
            tblDomain.Rows.Add(3, "Msn.com");
            tblDomain.Rows.Add(4, "Youtube.com");
            tblDomain.Rows.Add(5, "Myspace.com");
            tblDomain.Rows.Add(6, "Facebook.com");
            tblDomain.Rows.Add(7, "Wikipedia.org");
            return tblDomain;
        }
        private void BindGrid()
        {
            var tblDomain = GetDomains(); // load domains from database or wherever
            var tblData = new DataTable();// load sample data
            tblData.Columns.Add("EmployeeID", typeof(int));
            tblData.Columns.Add("EmployeeName");
            //add domains as DataTable-Columns 
            foreach (DataRow row in tblDomain.Rows)
            {
                String domaninName = row.Field<String>("DomainName");
                //Add column from domain-name
                tblData.Columns.Add(domaninName, typeof(bool)); //CheckBox-Checked is a boolean
            }
            //get some Employees and random checked state
            var rnd = new Random();
            var empRow = tblData.NewRow();
            empRow["EmployeeID"] = 1;
            empRow["EmployeeName"] = "Jon";
            foreach (DataRow dom in tblDomain.Rows)
            {
                empRow[dom.Field<String>("DomainName")] = rnd.Next(0, 2) == 0;
            }
            tblData.Rows.Add(empRow);
            empRow = tblData.NewRow();
            empRow["EmployeeID"] = 2;
            empRow["EmployeeName"] = "Eric";
            foreach (DataRow dom in tblDomain.Rows)
            {
                empRow[dom.Field<String>("DomainName")] = rnd.Next(0, 2) == 0;
            }
            tblData.Rows.Add(empRow);
            empRow = tblData.NewRow();
            empRow["EmployeeID"] = 3;
            empRow["EmployeeName"] = "Alain";
            foreach (DataRow dom in tblDomain.Rows)
            {
                empRow[dom.Field<String>("DomainName")] = rnd.Next(0, 2) == 0;
            }
            tblData.Rows.Add(empRow);
            GridView1.DataSource = tblData;
            GridView1.DataBind();
        }
        // show how to retrieve all checkbox values and the according EmployeeID
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0) return;
            var checkBoxColumns = GridView1.Columns.Cast<DataControlField>()
                .Select((bf,index) => new{Field=bf, Index=index})
                .Where(f => f.Field.GetType() == typeof(TemplateField) && ((TemplateField)f.Field).ItemTemplate.GetType() == typeof(GridViewCheckBoxTemplate))
                .ToArray();
            foreach (GridViewRow row in GridView1.Rows)
            {
                int EmployeeID = int.Parse(((HiddenField)row.FindControl("HiddenEmpID")).Value);
                foreach (var f in checkBoxColumns)
                {
                    String domain = f.Field.HeaderText;
                    bool isChecked = row.Controls[f.Index].Controls.OfType<CheckBox>().First().Checked;
                }
            }
        }
    }
