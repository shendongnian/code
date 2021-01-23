    for (int i = dtCurrentTable.Rows.Count; i < visitors; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)Gridview1.Rows[rowindex].Cells[1].FindControl("txtDate");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowindex].Cells[2].FindControl("TextBox2");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowindex].Cells[3].FindControl("TextBox3");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;
                    drCurrentRow["Column1"] = box1.Text;
                    drCurrentRow["Column2"] = box2.Text;
                    drCurrentRow["Column3"] = box3.Text;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    drCurrentRow = null;
                    rowindex++;
                }
