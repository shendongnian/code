                    if (row.Cells[i].Value == null)
                    {
                        MessageBox.Show("This row is empty")
                    }
                    else
                        {
                            UnsortArray[j] = row.Cells[i].Value.ToString();
                            MessageBox.Show(UnsortArray[j]);
                            ++j;
                        }
                }
