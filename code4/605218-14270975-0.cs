            private void PrintImage()
            {
                PrintDocument pd = new PrintDocument();
    
                pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                pd.OriginAtMargins = false;
                pd.DefaultPageSettings.Landscape = true;
    
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
    
    
                printPreviewDialog1.Document = pd;
                printPreviewDialog1.ShowDialog();
                
                //pd.Print();
            }
    
            void pd_PrintPage(object sender, PrintPageEventArgs e)
            {
                double cmToUnits = 100 / 2.54;
                e.Graphics.DrawImage(bmIm, 0, 0, (float)(15 * cmToUnits), (float)(10 * cmToUnits));
            }
    
            private void button5_Click(object sender, EventArgs e)
            {
                PrintImage();
            }
