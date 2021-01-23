    private void AddImage(ExcelWorksheet oSheet, int rowIndex, int colIndex, string imagePath)
    {
    	Bitmap image = new Bitmap(imagePath);
    	ExcelPicture excelImage = null;
    	if (image != null)
    	{
    		excelImage = oSheet.Drawings.AddPicture("Debopam Pal", image);
    		excelImage.From.Column = colIndex;
    		excelImage.From.Row = rowIndex;
    		excelImage.SetSize(100, 100);
    		// 2x2 px space for better alignment
    		excelImage.From.ColumnOff = Pixel2MTU(2);
    		excelImage.From.RowOff = Pixel2MTU(2);
    	}
    }
    
    public int Pixel2MTU(int pixels)
    {
    	int mtus = pixels * 9525;
    	return mtus;
    }
