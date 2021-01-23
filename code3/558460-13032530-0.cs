        public void PrintPreviewIncompleteJobsByStatus()
        {
            // Set new print document with custom page printing event handler
            chart.Printing.PrintDocument = new PrintDocument();
            chart.Printing.PrintDocument.PrintPage += new PrintPageEventHandler(ChartGenericFormat_PrintPage);
            chart.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
            // Print preview chart
            chart.Printing.PrintPreview();
        }
        private void ChartGenericFormat_PrintPage(object sender, PrintPageEventArgs ev)
        {
            // Calculate first chart position rectangle
            Rectangle chartPosition = new Rectangle(ev.MarginBounds.X, ev.MarginBounds.Y, ev.MarginBounds.Width, ev.MarginBounds.Height);
            // Draw chart on the printer graphics
            chart.Printing.PrintPaint(ev.Graphics, chartPosition);
        }
