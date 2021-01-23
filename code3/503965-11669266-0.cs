     Cell cell =new Cell(){ cellReference=A1 }; //Or other necessary details
     //Add value to cell in Double Format  then convert it into string using ToString()
     cell.cellValue = new CellValue(DateTime.Now().ToDouble().ToString()); 
     
     //Set the data type as Number
     Cell.DataType = new EnumValue<CellValues>(CellValues.Number);
     //Give its StyleIndex = 5
     cell.StyleIndex=5;
