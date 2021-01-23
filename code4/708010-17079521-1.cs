    // Function to export datagridview to excel sheet
    // excel_file contains the path to the excel file.
    public void export_to_excel(DataGridView dgv, string excel_file)
    {
        int cols;
        //Open file
        StreamWriter wr = new StreamWriter(excel_file);
        //Determine the number of columns and write columns to file
        cols = dgv.Columns.Count;
        for (int i = 0; i < cols; i++)
        {
            wr.Write(dgv.Columns[i].HeaderText.ToString().ToUpper() + "\t");
        }
        wr.WriteLine();
        //Write rows to the Excel file
        for (int i = 0; i < (dgv.Rows.Count - 1); i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (dgv.Rows[i].Cells[j].Value != null)
                    wr.Write(dgv.Rows[i].Cells[j].Value + "\t");
                else
                {
                    wr.Write("\t");
                }
            }
            wr.WriteLine();
        }
        //Close file
        wr.Close();
    }
