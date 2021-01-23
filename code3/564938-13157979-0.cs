    class formHdr : printObject
    {
        private string headerText;
        public formHdr(string hText)
            : base()
        {
            headerText = hText;
        }
        public override void printThis(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(headerText, FRHEADER, Brushes.Black, BaseX, BaseY);
        }
    }
