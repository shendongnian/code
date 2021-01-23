    partial class MyTrackBar : System.Windows.Forms.TrackBar
    {       
        protected override void  OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.FillRectangle([Brush color], ClientRectangle);
        }
    }
