    while (true) {
        // Split the satements 
        var columnACell = sheet.get_Range("A" + vIndex.ToString());
        var columnBCell = sheet.get_Range("B" + vIndex.ToString());
        var columnACellValue = columnACell.Value;
        var columnBCellValue = columnBCell.Value;
        if (columnACellValue != null && columnBCellValue != null) {
            vFirstName = columnACellValue.ToString();
            vLastName = columnBCellValue.ToString();
        } else {
            break;
        }
        this.SaveNewCustomer(vFirstName, vLastName);
        vIndex++;
    };
