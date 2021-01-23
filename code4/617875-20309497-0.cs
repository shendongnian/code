        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Query = string.Empty;
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                if (DropDownList1.SelectedValue.ToString() == "Name")
                {
                    Query = "select * from tbl_Employee where Name Like '" + txtSearchName.Text +  "%'";
                }
                else if (DropDownList1.SelectedValue.ToString() == "Designation")
                {
                    Query = "select * from tbl_Employee where Designation Like '" + txtSearchName.Text + "%'";
                }
                SqlDataAdapter sqlDa = new SqlDataAdapter(Query, sqlCon);
                DataSet Ds = new DataSet();
                sqlDa.Fill(Ds);
                dgvEmployee.DataSource = Ds;
                dgvEmployee.DataBind();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('wfrmGrid: 11')</script>" + ex.Message);
            }
        }
