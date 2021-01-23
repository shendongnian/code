    foreach (DataGridViewRow row in dataGridView1.Rows)     
    {
        if (row.Cells[i].Value == null)
        {
            //MessageBox.Show("This row is empty");
            break;
        }
        if (row.Cells[i].Value != null)
        {
            temp = row.Cells[i].Value.ToString();
            UnsortArray[i] = temp;
            i = i + 1;
    
        }
    }
        for (int a = 0; a < MaxZeilen; a++)
        {
            if (i < MaxZeilen)
            {
                if (String.Compare(UnsortArray[a], UnsortArray[a + 1]) > 0) 
                {
                  UnsortArray[a] = temp;
                  UnsortArray[a + 1] = temp2;
                  temp = UnsortArray[a + 1];
                  temp2 = UnsortArray[a];
               }
           }
        }
    for (int i = 0; i < MaxZeilen; i++)
    {
        UnsortArray[i] = SortArray[i];
        MessageBox.Show(UnsortArray[i]);
    }
