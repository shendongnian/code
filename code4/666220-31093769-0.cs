    public class ExtendedToolStripSeparator : ToolStripSeparator
    {
        public ExtendedToolStripSeparator()
        {
            this.Paint += ExtendedToolStripSeparator_Paint;
        }
    
        private void ExtendedToolStripSeparator_Paint(object sender, PaintEventArgs e)
        {
            // Get the separator's width and height.
            ToolStripSeparator toolStripSeparator = (ToolStripSeparator)sender;
            int width = toolStripSeparator.Width;
            int height = toolStripSeparator.Height;
    
            // Choose the colors for drawing.
            // I've used Color.White as the foreColor.
            Color foreColor = Color.FromName(Utilities.Constants.ControlsRelatedConstants.standardForeColorName);
            // Color.Teal as the backColor.
            Color backColor = Color.FromName(Utilities.Constants.ControlsRelatedConstants.standardBackColorName);
    
            // Fill the background.
            e.Graphics.FillRectangle(new SolidBrush(backColor), 0, 0, width, height);
    
            // Draw the line.
            e.Graphics.DrawLine(new Pen(foreColor), 4, height / 2, width - 4, height / 2);
        }
    }
