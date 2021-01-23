          public void ProcessRows(IEnumerable<Row> dataRows, SharedStringTable sharedString)
        {
            try
            {
                //Extract the information for each row 
                foreach (Row row in dataRows)
                {
                    var cellValues = from cell in row.Descendants<Cell>()
                                     select ((cell.CellValue != null && cell.DataType!=null && cell.DataType.HasValue  )
                                     && (sharedString.HasChildren  && int.Parse(cell.CellValue.InnerText) < sharedString.ChildElements.Count)
                                               ? sharedString.ChildElements[int.Parse(cell.CellValue.InnerText)].InnerText
                                               : ((cell.CellValue != null && cell.CellValue.InnerText != null)?cell.CellValue.InnerText:cell.CellValue.Text));
                    //Check to verify the row contained data.
                    if (cellValues != null && cellValues.Count() > 0)
                    {
                        //Create a productdetail object and add it to the list.
                        var values = cellValues.ToArray();
                        ProductItemDetail itemdetail = new ProductItemDetail();
                        itemdetail.RecordID = SessionRecordID;
                        if (values[0] != null)
                            itemdetail.Source = values[0].Trim();
                        if (values[1] != null)
                            itemdetail.Sourcename = values[1].Trim();
                        if (values[2] != null)
                            itemdetail.URLHomePage = values[2].Trim();
	            
                     
                    }
                {
		Catch(Exception ex)
		{
			throw ex;
                 }
        }
