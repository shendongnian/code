        private void button1_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dlg=new PrintPreviewDialog();
            PrintDocument doc=new PrintDocument();
            
            doc.PrintPage+=(s, pe) =>
            {
                userControl11.Render(pe.Graphics, pe.PageBounds); // user drawing
                pe.HasMorePages=false;                
            };
            doc.EndPrint+=(s, pe) => { dlg.Activate(); };
            dlg.Document=doc;
            dlg.Show();            
        }
