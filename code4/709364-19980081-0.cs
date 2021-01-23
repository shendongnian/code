     var printDialog = new System.Windows.Forms.PrintDialog();
            if (printDialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                w. = printDialog.PrinterSettings.PrinterName;
                d.PrintOut();
            }
            while (w.BackgroundPrintingStatus>0)
            {
                
            }
            d.Close(false);
            w.Quit();
