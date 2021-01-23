    For Excel cell to be in non-editable mode two things have to be taken care of -
    
    1) The Excel cell should be Locked
    ws.get_Range("Location", Type.Missing).Locked = true;
    
    2) The Excel worksheet should also be locked
    ws.Protect("SecurityCode", true, true, true,
                        Type.Missing, Type.Missing, true, true, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);
    
    //where ws is the worksheet object
    
    For your Second question to read through an Protected cell, this can be done directly
    string CellValue = ws.get_Range("Location", Type.Missing).Value2.ToString();
    
    //Now depending upon the CellValue you can write your own Logic.
