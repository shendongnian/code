          Please check this code.its working fine  
              try
                   {
                //Build the CSV file data as a Comma separated string.
                string csv = string.Empty;
                //Add the Header row for CSV file.
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    csv += column.HeaderText + ',';
                }
                //Add new line.
                csv += "\r\n";
                //Adding the Rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            //Add the Data rows.
                            csv += cell.Value.ToString().TrimEnd(',').Replace(",", ";") + ',';
                        }
                        // break;
                    }
                    //Add new line.
                    csv += "\r\n";
                }
                //Exporting to CSV.
                string folderPath = "C:\\CSV\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                File.WriteAllText(folderPath + "Invoice.csv", csv);
                MessageBox.Show("");
            }
            catch
            {
                MessageBox.Show("");
            }
