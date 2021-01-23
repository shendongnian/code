        protected void AddPrincipleStaff_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)// Bind nested grid view with parent grid view
            {
                var psid = DataBinder.Eval(e.Row.DataItem, "PrincipleStaffID");
                int intpsid = 0;
                intpsid = Int32.Parse(psid.ToString());
                using (var context = new FactoryTheaterModelFirstContainer())
                {
                    var query = (from c in context.PrincipleStaffs
                                 from p in c.Employees
                                 where c.PrincipleStaffID == intpsid
                                 select new
                                 {
                                     Name = p.empEmployeeName
                                 }).ToList();
                    if (query.Count > 0)
                    {
                        GridView childgrd = (GridView)e.Row.FindControl("ListEmployees"); // find nested grid view from parent grid veiw
                        childgrd.DataSource = query;
                        childgrd.DataBind();
                    }
                }
            }
