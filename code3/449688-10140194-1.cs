    FileStream fs = new FileStream(@"D:\sample.txt", FileMode.Open);
    StreamWriter sw = new StreamWriter(fs);
    for (int i = 0; i < gvEmp.Rows.Count; i++)
    {
        int colCount = gvEmp.Rows[i].Cells.Count;
        for (int j=0; j < colCount; j++)
        {
           sw.Write(gvEmp.Rows[i].Cells[j].Text + " , ");
        }
        sw.WriteLine();
    }
    sw.Flush();
    fs.Close();
