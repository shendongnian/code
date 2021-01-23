        private bool p = true;
        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (!p) {
                e.Graphics.DrawImage(new Bitmap(Foobar.Properties.Resources.bg), new Point());
            }
            string text = "This text to be printed. ";
            e.Graphics.DrawString(text, new Font("Georgia", 35, FontStyle.Bold),
                Brushes.Black, 10, 10);            
        }
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (e.PrintAction == System.Drawing.Printing.PrintAction.PrintToPreview) {
                p = false;
            }
        }
        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            p = true;
        }
