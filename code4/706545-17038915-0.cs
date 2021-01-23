    if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = null;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values
                            TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txt_type");
                            TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("txt_total");
                            TextBox box3 = (TextBox)Gridview1.Rows[i].Cells[3].FindControl("txt_max");
                            TextBox box4 = (TextBox)Gridview1.Rows[i].Cells[4].FindControl("txt_min");
                            TextBox box5 = (TextBox)Gridview1.Rows[i].Cells[5].FindControl("txt_rate");
        
                            drCurrentRow = dtCurrentTable.NewRow();
                            drCurrentRow["RowNumber"] = i + 1;
        
                            dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                            dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                            dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                            dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;
                            dtCurrentTable.Rows[i - 1]["Column5"] = box5.Text;
        
                            rowIndex++;
                        }
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        ViewState["CurrentTable"] = dtCurrentTable;
        
                        Gridview1.DataSource = dtCurrentTable;
                        Gridview1.DataBind();
                    }
                }
                else
                {
                    Response.Write("ViewState is null");
                }
