    public static void PrintReceiptForTransaction()
    {
        PrintDocument recordDoc = new PrintDocument();
        recordDoc.DocumentName = "Customer Receipt";
        recordDoc.PrintPage += new PrintPageEventHandler(ReceiptPrinter.PrintReceiptPage); // function below
        recordDoc.PrintController = new StandardPrintController(); // hides status dialog popup
                                                                    // Comment if debugging 
        PrinterSettings ps = new PrinterSettings();
        ps.PrinterName = "EPSON TM-T20II Receipt";
        recordDoc.PrinterSettings = ps;
        recordDoc.Print();
        // --------------------------------------
        // Uncomment if debugging - shows dialog instead
        //PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
        //printPrvDlg.Document = recordDoc;
        //printPrvDlg.Width = 1200;
        //printPrvDlg.Height = 800;
        //printPrvDlg.ShowDialog();
        // --------------------------------------
        recordDoc.Dispose();
    }
    private static void PrintReceiptPage(object sender, PrintPageEventArgs e)
    {
        float x = 10;
        float y = 5;
        float width = 270.0F; // max width I found through trial and error
        float height = 0F;
        Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
        Font drawFontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        // Set format of string.
        StringFormat drawFormatCenter = new StringFormat();
        drawFormatCenter.Alignment = StringAlignment.Center;
        StringFormat drawFormatLeft = new StringFormat();
        drawFormatLeft.Alignment = StringAlignment.Near;
        StringFormat drawFormatRight = new StringFormat();
        drawFormatRight.Alignment = StringAlignment.Far;
        // Draw string to screen.
        string text = "Company Name";
        e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
        y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;
        text = "Address";
        e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
        y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;
        // ... and so on
    }
