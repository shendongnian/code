    protected void Page_Load(object sender, EventArgs e)
        {
            SetInitialRow();
        }
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Question", typeof(string)));
            dt.Columns.Add(new DataColumn("Answer", typeof(string)));
            dr = dt.NewRow();
            dr["Question"] = string.Empty;
            dr["Answer"] = string.Empty;
            dt.Rows.Add(dr);
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)GridView1.Rows[i].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridView1.Rows[i].FindControl("TextBox2");
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Question"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Answer"] = box2.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //  Set Previous Data on Postbacks
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)GridView1.Rows[rowIndex].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridView1.Rows[rowIndex].FindControl("TextBox2");
                        box1.Text = dt.Rows[i]["Question"].ToString();
                        box2.Text = dt.Rows[i]["Answer"].ToString();
                        Session["Question1"] = box1.Text;
                        rowIndex++;
                    }
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }
        protected void prevRow_Click(object sender, EventArgs e)
        {
            SetPreviousData();
        }
