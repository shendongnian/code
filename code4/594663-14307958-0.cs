    //Auto Enlarge col width 
    private void largeurAuto(string NomCol) 
    { 
    XCellRange Range = null; 
    Range = feuille.getCellRangeByName(NomCol + "1"); //Recover the range, a cell is 
    
    XColumnRowRange RCol = (XColumnRowRange)Range; //Creates a collar ranks 
    XTableColumns LCol = RCol.getColumns(); // Retrieves the list of passes
    uno.Any Col = LCol.getByIndex(0); //Extract the first Col
    
    XPropertySet xPropSet = (XPropertySet)Col.Value; 
    xPropSet.setPropertyValue("OptimalWidth", new uno.Any((bool)true)); 
    }
