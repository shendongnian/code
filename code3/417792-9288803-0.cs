                    if (j < 4)
                    {
                        cell.InnerText = datarow[j].ToString();
                    }
                    else
                    {
                        CheckBox checkbox = new CheckBox();
                        int checkBoxColumns = dv.Table.Columns.Count - 5;
                        string fieldvalue = datarow[j].ToString();
                        string yes = fieldvalue.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        string courseid = fieldvalue.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)[0];
                        checkbox.ID = row.Cells[3].InnerText + "," + courseid.Trim();
                        checkbox.Checked = yes.Equals("Yes");
                        cell.Controls.Add(checkbox);
                        // set field background color  
                        if (datarow[0].Equals(1)){
                            cell.BgColor = "Blue";
                        else if (datarow[0].Equals(2))
                            cell.BgColor = "Yellow";
                    }
