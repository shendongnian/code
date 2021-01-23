        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrintPreviewIcon != null)
            {
                PrintPreviewTimer.Enabled = true;
            }
            PlotChart.Printing.PrintPreview();
        }
        private void PrintPreviewTimer_Tick(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is PrintPreviewDialog)
                {
                    f.Icon = PrintPreviewIcon;
                    PrintPreviewTimer.Enabled = false;
                }
            }
        }
