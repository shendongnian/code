    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    namespace Test
    {
	public class Print
	{
		PrintDocument myPrintDocument = new PrintDocument();
		public void ShowPrintDialog()
		{
			PrintDialog myDialog = new PrintDialog();
			myDialog.Document = myPrintDocument;
			if(myDialog.ShowDialog() == DialogResult.OK)
				Print();
		}
		protected override void OnPrintPage(PrintPageEventArgs e)
		{
			e.Graphics.DrawString("Your String To Print In Document", this.Font, Brushes.Red, new PointF());
			e.HasMorePages = false;
		}
	}
    }
