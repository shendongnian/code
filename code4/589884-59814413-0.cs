	public class CustomForm : Form
	{
		protected Bitmap _prnImage;
		protected PrintPreviewDialog _prnpreviewdlg = new PrintPreviewDialog();
		protected PrintDocument _printdoc = new PrintDocument();
		public CustomForm()
		{
			_printdoc.PrintPage += new PrintPageEventHandler(printdoc_PrintPage);
		}
		protected void PrintForm()
		{
			Form form = this;
			_prnImage = new Bitmap(form.Width, form.Height);
			form.DrawToBitmap(_prnImage, new Rectangle(0, 0, form.Width, form.Height));
			_printdoc.DefaultPageSettings.Landscape = true;
			_printdoc.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
			_prnpreviewdlg.Document = _printdoc;
			_prnpreviewdlg.ShowDialog();
		}
		protected void printdoc_PrintPage(object sender, PrintPageEventArgs e)
		{
			Rectangle pagearea = e.PageBounds;
			e.Graphics.DrawImage(_prnImage, e.MarginBounds);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			if (_prnImage != null)
			{
				e.Graphics.DrawImage(_prnImage, 0, 0);
				base.OnPaint(e);
			}
		}
	}
