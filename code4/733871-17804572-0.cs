            int cols;
            //open file
            StreamWriter wr = new StreamWriter(excel_file);
            //determine the number of columns and write columns to file
            cols = dgv.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                wr.Write(dgv.ColumnsIdea.Name.ToString().ToUpper() + "\t");
            }
            wr.WriteLine();
            //write rows to excel file
            for (int i = 0; i < (dgv.Rows.Count - 1); i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (dgv.RowsIdea.Cells[j].Value != null)
                        wr.Write(dgv.RowsIdea.Cells[j].Value + "\t");
                    else
                    {
                        wr.Write("\t");
                    }
                }
                wr.WriteLine();
            }
            //close file
            wr.Close();
        }
