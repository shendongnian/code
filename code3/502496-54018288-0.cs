    if (dtBirdsDetail.Rows.Count > 0)
        {
          litBirdsTable.Text = "<center><table id='tbldata' cellspacing='0' cellpadding='1' border='1' style='border-collapse: collapse;'>" + System.Environment.NewLine;
          litBirdsTable.Text += "<tr>";
                        
          //add datatable columns to html table as heading
    for (int liColumnIndex = 0; liColumnIndex < dtBirdsDetail.Columns.Count;liColumnIndex++)
           {
             litBirdsTable.Text += "<th>" + dtBirdsDetail.Columns[liColumnIndex].ColumnName 
                                 + "</th>" +   System.Environment.NewLine;
           }
           litBirdsTable.Text += System.Environment.NewLine + "</tr>";
        
           //add datatable rows to html table
           for (int liRowIndex = 0; liRowIndex < dtBirdsDetail.Rows.Count; liRowIndex++)
           {
             litBirdsTable.Text += "<tr>";
             litBirdsTable.Text += "<td>" + dtBirdsDetail.Rows[liRowIndex]["ID"] + "</td>" +              
                                    System.Environment.NewLine;
             litBirdsTable.Text += "<td>" + dtBirdsDetail.Rows[liRowIndex]["BirdName"] + " 
                                   </td>" + System.Environment.NewLine;
             litBirdsTable.Text += "<td>" + dtBirdsDetail.Rows[liRowIndex]["TypeOfBird"] + " 
                                   </td>" + System.Environment.NewLine;
             litBirdsTable.Text += "<td>" + dtBirdsDetail.Rows[liRowIndex]["ScientificName"] 
                                 + "</td>" + System.Environment.NewLine;
             litBirdsTable.Text += "</tr>";
           }
            litBirdsTable.Text += "</table></center>";
        }
