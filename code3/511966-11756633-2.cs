     PrintDocument printDocument1 = new PrintDocument();
            var printerSettings = new System.Drawing.Printing.PrinterSettings();
            printerSettings.PrinterName = "Printer name";// optional
            //printerSettings.PrinterName = "HP Officejet J6400 series";
            printDocument1.PrinterSettings = printerSettings;
            printDocument1.PrintPage += printDocument1_PrintPage;
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;
    // in the dialog, you can set up the paper size, etc.
            printDialog1.UseEXDialog = true;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
            printDocument1.Print();
            }
