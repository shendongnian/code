            TableRow tableRow;
            TableCell tableCell;
            TableCell tableCell2;
            foreach (DataTable dataTable in ds.Tables)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    tableRow = new TableRow();
                    tableCell = new TableCell();
                    tableCell.Text = dataRow["QUESTIONTEXT"].ToString();
                    tableCell2 = new TableCell();
                    switch (dataRow["TYPEID"].ToString())
                    {
                        case "1":
                            Label lbl = new Label();
                            lbl.Text = "";
                            tableCell2.Controls.Add(lbl);
                            break;
                        case "2":
                            CheckBox chk = new CheckBox();
                            chk.Text = "";
                            tableCell2.Controls.Add(chk);
                            break;
                    }
                    tableRow.Cells.Add(tableCell);
                    tableRow.Cells.Add(tableCell2);
                    myTable.Rows.Add(tableRow);
                }
            }
