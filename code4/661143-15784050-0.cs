    Session["DataTable"]=null;
    using (var db = new KnowItCvdbEntities())
    {
        if (_emp != null)
        {
            var assignmentList = from p in db.EMPLOYEES_ASSIGNMENT.AsEnumerable()
                                 join at in db.ASSIGNMENT_TOOLS.AsEnumerable() on p.assignment_id equals at.assignment_id
                                 join ate in db.ASSIGNMENT_TECHNOLOGY.AsEnumerable() on p.assignment_id equals ate.assignment_id
                                 where p.employee_id == theEmpl.employee_id
                                 select new EmployeeAssignmentInfo
                                 {
                                     CompanyName = p.company_name,
                                     AssignmentId = p.assignment_id,
                                     Area = p.area,
                                     From = p.from_date,
                                     To = p.to_date,
                                     Description = p.description,
                                     Sector = p.sector,
                                     Reference = p.reference_name,
                                     ToolName = at.tool_name,
                                     AssignmentToolsId = at.assignment_tools_id,
                                     TechnologyName = ate.technology_name,
                                     AssignmentTechnologyId = ate.assignment_technology_id
                                 };
          var dt = new DataTable();
      
            foreach (var vAssignment in assignmentList)
            {
                //Populate gridview  
              
                if (Session["DataTable"] != null)
                {
                    dt = (DataTable)Session["DataTable"];
                }
                else
                {
                    dt.Columns.Add("Company name");
                    dt.Columns.Add("Sector");
                    dt.Columns.Add("Area");
                    dt.Columns.Add("From");
                    dt.Columns.Add("To");
                    dt.Columns.Add("Tools");
                    dt.Columns.Add("Technology");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Reference");
                    dt.Rows.Clear();
                }
                DataRow dr = dt.NewRow();
                dr["Company name"] = vAssignment.CompanyName;
                dr["Sector"] = vAssignment.Sector;
                dr["Area"] = vAssignment.Area;
                dr["From"] = vAssignment.From;
                dr["To"] = vAssignment.To;
                dr["Description"] = vAssignment.Description;
                dr["Reference"] = vAssignment.Reference;
                dr["Tools"] = vAssignment.ToolName + " ";
                dr["Technology"] = vAssignment.TechnologyName + " ";
                dt.Rows.Add(dr);
               
            }
                Session["DataTable"] = dt;
                GridViewShowAssignments.DataSource = dt;
                GridViewShowAssignments.DataBind();
        }
        else
        {
            LabelPleaseRegister.Visible = true;
            LabelPleaseRegister.Text = "Please register your personal information";
            PanelRegisterCv.Visible = false;
            PanelRegisterPersonalInfo.Visible = false;
        }
    }
