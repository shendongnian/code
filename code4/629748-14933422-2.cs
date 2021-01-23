        protected void btnTextDisplay_Click(object sender, EventArgs e)
        {
            List<Employee> list;
            if (Session["list"] == null)
            {
                list = new List<Employee>();
            }
            else
            {
                list = (List<Employee>)Session["list"];
            }
            list.Add(new Employee() { FirstName = txtName.Text, City = txtCity.Text }); //store textbox values in the array list
            Session["list"] = list;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("City");
            foreach (var emp in list)
            {
                dt.Rows.Add(emp.FirstName,emp.City)
            }
            gvDisplay.DataSource = dt;
            gvDisplay.DataBind();
        }
