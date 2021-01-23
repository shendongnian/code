    Table myTable = doc.Body.Descendants<Table>().First();
    TableRow theRow = myTable.Elements<TableRow>().Last();
    for (int i = 0; i < 5; i++)
    {
        TableRow rowCopy = (TableRow)theRow.CloneNode(true);
	
        var runProperties = GetRunPropertyFromTableCell(rowCopy, 0);
        var run = new Run(new Text(i.ToString() + " 1"));
        run.PrependChild<RunProperties>(runProperties);
        rowCopy.Descendants<TableCell>().ElementAt(0).RemoveAllChildren<Paragraph>();//removes that text of the copied cell
        rowCopy.Descendants<TableCell>().ElementAt(0).Append(new Paragraph(run));
        //I only get the the run properties from the first cell in this example, the rest of the cells get the document default style. 
        rowCopy.Descendants<TableCell>().ElementAt(1).RemoveAllChildren<Paragraph>();
        rowCopy.Descendants<TableCell>().ElementAt(1).Append(new Paragraph(new Run(new Text(i.ToString() + " 2"))));
        rowCopy.Descendants<TableCell>().ElementAt(2).RemoveAllChildren<Paragraph>();
        rowCopy.Descendants<TableCell>().ElementAt(2).Append(new Paragraph(new Run(new Text(i.ToString() + " 3"))));
        
        myTable.AppendChild(rowCopy);
    }
    myTable.RemoveChild(theRow); //you may want to remove this line. I have it because in my code i always have a empty row last in the table that i copy.
