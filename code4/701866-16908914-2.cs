    private void AddNewRowToGrid()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            
                var drCurrentRow = dtCurrentTable.NewRow();
                dtCurrentTable.Rows.Add(drCurrentRow);
            // Updated from > 0 to > 1 since the first action you're taking is in GridView1.Rows[1] via the for loop below
            if (dtCurrentTable.Rows.Count > 1)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                    TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                    TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                    dtCurrentTable.Rows[i - 1]["Question"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Hints No.1"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Hints No.2"] = box3.Text;
                    rowIndex++;
                }
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
