        foreach (DataGridViewRow row in dataGridView1.Rows)   
                        {
                          for (int i=0; i<= dataGridView1.Columns.Count; i++)
    {
                            **if (row.Cells[i].Value == null)**
                            {
                                MessageBox.Show("This row is empty");
                               
                            }
                                if (row.Cells[i].Value != null)
                                {
                                    UnsortArray[i] = row.Cells[i].Value.ToString();
                                    MessageBox.Show(UnsortArray[i]);
                                    
                                }
        
        }
        
        
        
                        }
