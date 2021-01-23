     private void AddNewRowToGrid()
            {
                int rowIndex = 0;
        
                CheckBox chkbox1 = (CheckBox)GridView1.Rows[rowIndex].Cells[2].FindControl("CheckBox1");
                CheckBox chkbox2 = (CheckBox)GridView1.Rows[rowIndex].Cells[2].FindControl("CheckBox2");
        
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = null;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values
                            TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                            TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                            TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox3");
        
                            drCurrentRow = dtCurrentTable.NewRow();
        
        
                            dtCurrentTable.Rows[i - 1]["Question"] = box1.Text;         
                            dtCurrentTable.Rows[i - 1]["Hints"] = box2.Text;
                            dtCurrentTable.Rows[i - 1]["Hints1"] = box3.Text;
        
        
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
        
             private void SetInitialRow()
            {
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("Question", typeof(string)));
                dt.Columns.Add(new DataColumn("Hints", typeof(string)));
                dt.Columns.Add(new DataColumn("Hints1", typeof(string)));
        
                dr = dt.NewRow();
                dr["Question"] = string.Empty;
                dr["Hints"] = string.Empty;
                dr["Hints1"] = string.Empty;
        
        
                dt.Rows.Add(dr);
        
        
                //Store the DataTable in ViewState
                ViewState["CurrentTable"] = dt;
        
                GridView1.DataSource = dt;
                GridView1.DataBind();
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
                            TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                            TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                            TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox3");
        
        
        
                            //Setting previous text to the respective textboxes based on columns.
                            box1.Text = dt.Rows[i]["Question"].ToString();
                            box2.Text = dt.Rows[i]["Hints"].ToString(); 
                            box3.Text = dt.Rows[i]["Hints1"].ToString(); 
        
        
                            Session["Question1"] = box1.Text;
                            rowIndex++;
                        }
                    }
                }
            }
