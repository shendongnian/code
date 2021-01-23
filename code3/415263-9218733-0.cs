        private void MyPrintDocument_PrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = DrawItems(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }
