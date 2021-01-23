    public delegate void FormatCellEventHandler(object sender, DataGridFormatCellEventArgs e);
	public class DataGridFormatCellEventArgs : EventArgs
	{
		public int Column;					//The column number of the cell being painted.
		public int Row;						//The row number of the cell being painted.
		public object CurrentCellValue;		//The current cell value.
		public Font TextFont;				//The font to be used to draw text in the cell.
		public Brush BackBrush;				//The brush used to paint the cell's background.
		public Brush AlphaBackBrush;		//Used to shade a cell with an alpha mask (e.g. selected cell)
		public Brush ForeBrush;				//The brush used to paint the text in the cell.
		public bool TextFontDispose;		//True to call the TextFont.Dispose.
		public bool BackBrushDispose;		//True to call the BackBrush.Dispose.
		public bool ForeBrushDispose;		//True to call the ForeBrush.Dispose.
		public bool UseBaseClassDrawing;	//True to call the MyBase.Paint.
		public DataGridFormatCellEventArgs(int row, int col, object cellValue)
		{
			this.Row = row;
			this.Column = col;
			this.CurrentCellValue = cellValue;
		}
