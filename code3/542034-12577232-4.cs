    int cnt = 0;
    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++ )
                        {
                            if (row.Cells[i].Value != null)
                            {
                                temp = row.Cells[i].Value.ToString();
                                UnsortArray[cnt] = temp;
                                cnt++;
                            } 
                        }
                       
                    }
    for (int b = 0; b < MaxZeilen; b++)
    {    
      for (int a = 0; a < MaxZeilen; a++)   
         {    
    
        if (String.Compare(UnsortArray[a], UnsortArray[a + 1]) > 0)
         {
    
          temp = UnsortArray[a + 1];
          UnsortArray[a + 1] = UnsortArray[a];
          UnsortArray[a] = temp;
    
        }    
      }    
    }
