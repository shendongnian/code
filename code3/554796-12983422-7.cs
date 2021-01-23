    public class FormattableTextBoxColumn : DataGridTextBoxColumn
	{
		public event FormatCellEventHandler SetCellFormat;
		protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
		{
			DataGridFormatCellEventArgs e = new DataGridFormatCellEventArgs(rowNum, source);
			e.ForeBrush = foreBrush;
			e.BackBrush = backBrush;
			OnSetCellFormat(e);
			base.Paint(g, bounds, source, rowNum, e.BackBrush, e.ForeBrush, alignToRight);
		}
		private void OnSetCellFormat(DataGridFormatCellEventArgs e)
		{
			FormatCellEventHandler handler = SetCellFormat;
			if (handler != null)
				handler(this, e);
		}
	}
