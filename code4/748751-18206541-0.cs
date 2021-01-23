    string file_name = "C:\\test1.txt";
    System.IO.StreamWriter objWriter;
    objWriter = new System.IO.StreamWriter(file_name);
    int count = dgv.Rows.Count;
    for (int row = 0; row < count; row++)
    {
        int colCount = dgv.Rows[row].Cells.Count; 
        for ( int col = 0; col < colCount; col++)  
        {
            objWriter.WriteLine(dgv.Rows[row].Cells[col].Value.ToString());
        }
        // record seperator could be written here.
    }
 
    objWriter.Close();
