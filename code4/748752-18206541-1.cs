    string file_name = "C:\\test1.txt";
    System.IO.StreamWriter objWriter;
    objWriter = new System.IO.StreamWriter(file_name);
    int count = dgv.Rows.Count;
    for (int row = 0; row < count; row++)
    {
        int colCount = dgv.Rows[row].Cells.Count;
        for ( int col = 0; col < colCount; col++)  
        {
            // EDIT inserted if statement
            string selectedValue = dropboxClientList.SelectedValue.ToString();
            string currentValue = dgv.Rows[row].Cells[col].Value.ToString();
            string clientName = dgv.Rows[row].Cells[1].Value.ToString();
      
            if (dgv.Rows[row].Cells[col].Value.ToString().Contains(selectedValue)
            {
                objWriter.WriteLine(currentValue );
            }
        }
        // record seperator could be written here.
    }
 
    objWriter.Close();
