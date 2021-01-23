    bool rep = xlWorkSheet.Cells.Find(textBox1.Text, 
                                      Type.Missing,
                                      Type.Missing, 
                                      Excel.XlLookAt.xlWhole, 
                                      Excel.XlSearchOrder.xlByRows,
                                      Type.Missing, 
                                      false, 
                                      Type.Missing, 
                                      Type.Missing);
    if (rep)
               xlWorkSheet.Cells.Replace(textBox1.Text, 
                                         textBox2.Text, 
                                         Excel.XlLookAt.xlWhole, 
                                         Excel.XlSearchOrder.xlByRows, 
                                         false, 
                                         Type.Missing, 
                                         Type.Missing, 
                                         Type.Missing);
