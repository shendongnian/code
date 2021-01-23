        protected void bindDdls()
        {
            DataTable dt = new DataTable();
            try
            {
                ddlpid1.Items.Clear();
                ddlpid2.Items.Clear();
                using (var connAdd = new SqlConnection("Data Source = localhost; Initial Catalog = MajorProject; Integrated Security= SSPI"))
        {
            connAdd.Open();
            var sql = "Select policeid from PoliceAccount where status ='available' and handle ='offcase' and postedto='" + ddllocation.SelectedValue + "'";
            using (var cmdAdd = new SqlDataAdapter(sql, connAdd))
            {
                DataSet ds2 = new DataSet();
                cmdAdd.Fill(ds2);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ddlpid1.DataSource = dt;
                    ddlpid1.DataTextField = dt.Columns["policeid"].ToString();
                    ddlpid1.DataValueField = dt.Columns["policeid"].ToString();
                    ddlpid1.DataBind();
                    ddlpid1.Items.Insert(0, new ListItem("Select", "Select"));
                }
                else
                {
                    ddlpid1.Items.Clear();
                    ddlpid1.DataSource = null;
                    ddlpid1.DataBind();
                    ddlpid1.Items.Insert(0, new ListItem("Select", "Select"));
                }
                if (Cache["PoliceData"] == null)
                {
                    Cache.Insert("PoliceData", dt);
                }
                else
                {
                    Cache.Remove("PoliceData");
                    Cache.Insert("PoliceData", dt);
                }
                connAdd.Close();
                }
              }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (connAdd.State == connAdd.Open)
                    connAdd.Close();
            }
        }
        protected void ddlpid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlpid1.SelectedValue != "Select")
            {
                bindSecondDropdown();
            }
        }
        protected void bindSecondDropdown()
        {
            DataTable dt = new DataTable();
            DataTable dtFiltered = new DataTable();
            try
            {
                ddlpid2.Items.Clear();
                if (Cache["PoliceData"] != null)
                {
                    dt = (DataTable)Cache["PoliceData"];
                    if (ddlpid1.SelectedValue != "Select" && !string.IsNullOrEmpty(ddlpid1.SelectedValue))
                        dt.DefaultView.RowFilter = "[policeID] <> " + ddlpid1.SelectedValue;
                    else
                        dt.DefaultView.RowFilter = "[policeID] <> " + 0;
                    dtFiltered = dt.DefaultView.ToTable();
                }
                if (dt.Rows.Count > 0)
                {
                    ddlpid2.DataSource = dtFiltered;
                    ddlpid2.DataTextField = dtFiltered.Columns["policeid"].ToString();
                    ddlpid2.DataValueField = dtFiltered.Columns["policeid"].ToString();
                    ddlpid2.DataBind();
                    ddlpid2.Items.Insert(0, new ListItem("Select", "Select"));
                }
                else
                {
                    ddlpid2.Items.Clear();
                    ddlpid2.DataSource = null;
                    ddlpid2.DataBind();
                    ddlpid2.Items.Insert(0, new ListItem("Select", "Select"));
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
