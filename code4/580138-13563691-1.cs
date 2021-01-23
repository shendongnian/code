    int cols;
    //open file 
    StreamWriter wr = new StreamWriter("GB STOCK.csv");
    //determine the number of columns and write columns to file 
    cols = dgvStock.Columns.Count;
    for (int i = 0; i < cols - 1; i++)
    { 
        wr.Write(dgvStock.Columns[i].Name.ToString().ToUpper() + ",");
    } 
    wr.WriteLine();
    //write rows to excel file
    for (int i = 0; i < (dgvStock.Rows.Count - 1); i++)
    { 
        for (int j = 0; j < cols; j++)
        { 
            if (dgvStock.Rows[i].Cells[j].Value != null)
            {
                wr.Write(dgvStock.Rows[i].Cells[j].Value + ",");
            }
            else 
            {
                wr.Write(",");
            }
        }
        wr.WriteLine();
    }
    //close file
    wr.Close();
