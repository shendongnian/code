        private int PrintRow;
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            PrintRow = 0;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            for (int lines = 0; lines < 48; ++lines) {
                PrintRow++;
                if (PrintRow >= rows.Rows.Count) return;  // Done printing
                var row = rows.Rows[PrintRow];
                // Print row
                //...
            }
            e.HasMorePages = PrintRow < rows.Rows.Count;
        }
