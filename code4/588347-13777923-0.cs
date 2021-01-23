        private int values;
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            values = 0;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            values++;
            // etc...
        }
