    StringBuilder sb = new StringBuilder();
    for (int rowNumber = startRow + 1; rowNumber <= currentWorkSheet.Dimension.End.Row; rowNumber++)
            // read each row from the start of the data (start row + 1 header row) to the end of the spreadsheet.
    {
        try
        {
 
            object col1Value = currentWorkSheet.Cells[rowNumber, 1].Value;
            object col2Value = currentWorkSheet.Cells[rowNumber, 2].Value;
            object col3Value = currentWorkSheet.Cells[rowNumber, 3].Value;
            object col4Value = currentWorkSheet.Cells[rowNumber, 4].Value;
            if ((col1Value != null && col2Value != null))
            {
                exampleDataList.Add(new PersonalData
                {
                    firstname = col1Value.ToString(),
                    lastname = col2Value.ToString(),
                    currentDate = col3Value == null ? DateTime.MinValue : Convert.ToDateTime(col3Value),
                    mySalary = col4Value == null ? 0 : Convert.ToInt32(col4Value)
                });
            }
        }      
        catch (Exception e)
        {
             //log exception here
            sb.AppendFormat("{0}: {1}{2}",rowNumber, e.Message, Environment.NewLine);           
        }
    } 
    //convert the StringBuilder into the final string object
    string allMessages = sb.ToString();
