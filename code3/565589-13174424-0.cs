    using (System.Drawing.Image img = /*...Load image here...*/)
    {
	if (img != null)
	{
		//set row height to accommodate the picture
		ws.Row(currentRow).Height = ExcelHelper.Pixel2RowHeight(pictureHeight + 1);
		//add picture to cell
		ExcelPicture pic = ws.Drawings.AddPicture("PictureUniqueName", img);
		//position picture on desired column
		pic.From.Column = pictureCol - 1;
		pic.From.Row = currentRow - 1;
		pic.From.ColumnOff = ExcelHelper.Pixel2MTU(1);
		pic.From.RowOff = ExcelHelper.Pixel2MTU(1);
		//set picture size to fit inside the cell
		pic.SetSize(pictureWidth, pictureHeight);
	}
    }
