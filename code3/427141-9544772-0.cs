        void LoadStuff(int id, TextBox control){
                orgDa.SelectCommand = conn.CreateCommand();
                orgDa.SelectCommand.CommandText = "select OrganizationName from Organizationtbl where OrgID=@orgId";
                orgDa.SelectCommand.CommandType = CommandType.Text;
                var parameter = orgDa.SelectCommand.CreateParameter();
                parameter.ParameterName = "@orgId";
                parameter.Value = id;
                orgDa.SelectCommand.AddParameter(parameter);
                orgDa.Fill(ds, "Organizationtbl");
                deptDa.SelectCommand = conn.CreateCommand();
                deptDa.SelectCommand.CommandText = "select DepartmentName from Departmenttbl where DeptID=@deptID";
                deptDa.SelectCommand.CommandType = CommandType.Text;
                parameter = orgDa.SelectCommand.CreateParameter();
                parameter.ParameterName = "@deptID";
                parameter.Value = id;
                orgDa.SelectCommand.AddParameter(parameter);
                deptDa.Fill(ds, "Departmenttbl");
                if (ds.Tables["Organizationtbl"].Rows.Count == 1)
                {
                    foreach (DataRow orgItem in ds.Tables["Organizationtbl"].Rows)
                    {
                        if (orgItem.IsNull("OrganizationName"))
                        {
                            foreach (DataRow deptItem in ds.Tables["Departmenttbl"].Rows)
                            {
                                control.Text = deptItem["DepartmentName"].ToString();
                            }
                        }
                        else
                        {
                            control.Text = orgItem["OrganizationName"].ToString();
                        }
                    }
                }
                else
                {
                    foreach (DataRow deptItem in ds.Tables["Departmenttbl"].Rows)
                    {
                        if (deptItem.IsNull("DepartmentName"))
                        {
                            foreach (DataRow orgItem in ds.Tables["Organizationtbl"].Rows)
                            {
                                control.Text = orgItem["OrganizationName"].ToString();
                            }
                        }
                        else
                        {
                            control.Text = deptItem["DepartmentName"].ToString();
                        }
                    }
                }
        }
