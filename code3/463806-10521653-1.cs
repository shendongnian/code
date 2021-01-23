    class Program
    {
    	static void Main(string[] args)
    	{
    		File.Copy("book.xlsx", "output.xlsx", true);
    		WriteRandomValuesSAX("output.xlsx", 10, 10);
    	}
    
    	static void WriteRandomValuesSAX(string filename, int numRows, int numCols)
    	{
    		using (SpreadsheetDocument myDoc = SpreadsheetDocument.Open(filename, true))
    		{
    			WorkbookPart workbookPart = myDoc.WorkbookPart;
    			WorksheetPart worksheetPart = workbookPart.WorksheetParts.Last();
    
    			OpenXmlWriter writer = OpenXmlWriter.Create(worksheetPart);
    
    			Row r = new Row();
    			Cell c = new Cell();
    			CellValue v = new CellValue("Test");
    			c.AppendChild(v);
    
    			writer.WriteStartElement(new Worksheet());
    			writer.WriteStartElement(new SheetData());
    			for (int row = 0; row < numRows; row++)
    			{
    				writer.WriteStartElement(r);
    				for (int col = 0; col < numCols; col++)
    				{
    					writer.WriteElement(c);
    				}
    				writer.WriteEndElement();
    			}
    			writer.WriteEndElement();
    			writer.WriteEndElement();
    
    			writer.Close();
    		}
    	}
    }
