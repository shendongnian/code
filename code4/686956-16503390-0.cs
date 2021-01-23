    using System.Drawing;
    private void printButton_Click(object sender, EventArgs e) 
    {
    PrintDocument pd = new PrintDocument();
    pd.PrintPage += new PrintPageEventHandler
                (this.pd_PrintPage); 
    pd.Print();
    }
    // The PrintPage event is raised for each page to be printed.
    void pd_PrintPage(Object* /*sender*/, PrintPageEventArgs* ev) 
    {
    Font myFont = new Font( "m_svoboda", 14, FontStyle.Underline, GraphicsUnit.Point );
 
    float lineHeight = myFont.GetHeight( e.Graphics ) + 4;
 
    float yLineTop = e.MarginBounds.Top;
 
    string text = "Coupon\n";
    foreach (DataGridViewRow dgvRow in dataGridViewCarrinho.Rows)
        {
            foreach (DataGridViewCell dgvCell in dgvRow.Cells)
            {
                text += dgvCell.Value.ToString() + "  ";
            }
            text += "\n";
        }
        //MessageBox.Show(text);
        // I should print the coupon here
        e.Graphics.DrawString( text, myFont, Brushes.Black,
        new PointF( e.MarginBounds.Left, yLineTop ) );
        yLineTop += lineHeight;
    }
