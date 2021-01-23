    /// <summary>
	/// Summary description for FormattableTextBoxColumn.
	/// </summary>
	public class FormattableTextBoxColumn : DataGridTextBoxColumn
	{
		public event FormatCellEventHandler SetCellFormat;
		
		protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
		{
			DataGridFormatCellEventArgs e;
			//Get the column number
			int col = this.DataGridTableStyle.GridColumnStyles.IndexOf(this);    
			//Create the eventargs object
			e = new DataGridFormatCellEventArgs(rowNum, col, this.GetColumnValueAtRow(source, rowNum));
			
			//Console.WriteLine(counter++);
			//fire the formatting event
			if(SetCellFormat != null)
				SetCellFormat(this, e);
			bool callBaseClass = true;
			// check the brushes returned from the event
			if(e.BackBrush != null)
			{
				backBrush = e.BackBrush;
			}
			if(e.ForeBrush != null) 
			{
				foreBrush = e.ForeBrush;
			}
			if(e.TextFont != null)
			{
				try
				{
					int charWidth = (int)(Math.Ceiling(g.MeasureString("c", e.TextFont, 20, StringFormat.GenericTypographic).Width));
					string s = this.GetColumnValueAtRow(source, rowNum).ToString();
					int maxChars = Math.Min(s.Length, bounds.Width / charWidth);
					try
					{
						g.FillRectangle(backBrush, bounds);
						g.DrawString(s.Substring(0, maxChars), e.TextFont, foreBrush, bounds.X, bounds.Y + 2);
					}
					catch(Exception ex)
					{
						Console.WriteLine(ex.Message.ToString());
					}				
				}
				catch(Exception){} //empty catch			
				callBaseClass = false;
			}
			// check the UseBaseClassDrawing property
			if(!e.UseBaseClassDrawing)
			{
				callBaseClass = false;
			}
			if(callBaseClass)
				base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
			
			if(e.AlphaBackBrush != null)
			{
				Pen outlineBorder = new Pen(new SolidBrush(Color.Black), 2F);
				g.FillRectangle(e.AlphaBackBrush, bounds);
				
				g.DrawLine(outlineBorder, new Point(bounds.Left, bounds.Bottom-1), new Point(bounds.Right, bounds.Bottom-1));
				g.DrawLine(outlineBorder, new Point(bounds.Left, bounds.Top+1), new Point(bounds.Right, bounds.Top+1));
			}
			
			if(e != null)
			{
				if(e.BackBrushDispose)
					e.BackBrush.Dispose();
				if(e.ForeBrushDispose)
					e.ForeBrush.Dispose();
				if(e.TextFontDispose)
					e.TextFont.Dispose();
			}
		}
	}
