    Error
    string[] output = new string[dgvLista_Apl_Geral.RowCount + 1];
    
    Correction
    string[] output = new string[DGV.RowCount + 1];
    
    Error
    System.IO.File.WriteAllLines(filename, output, System.Text.Encoding.UTF8);
    
    Correction
    System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
