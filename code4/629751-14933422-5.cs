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
            gvDisplay.DataSource = list; //directly bind the list to the grid
            gvDisplay.DataBind();
        }
