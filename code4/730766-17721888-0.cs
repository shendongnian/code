    for(int row = 0; row < list1.Count(); row++)
    {
        for(int cell = 0; cell < list2.Count(); cell++)
        {
             dataGridView1.Rows[row].Cells[cell].Value = i + " and " + d; 
        }
    }
