        ///<summary>
        ///  Most common method for painting to the screen. 
        ///  Available on all control class objects by overriding 
        ///  the OnPaint method of the base class.
        ///</summary>
        protected virtual new void OnPaint(PaintEventArgs e)
        {
            // We assume here that your control's screen graphics 
            // area is at least 500x400 to see the full results 
            // otherwise please resize your form or control to accomodate
            // Define your parent border size
            Size ParentBorder = new Size(400, 300);
            // Initialize a new bitmap having a size of ParentBorder and set 
            // it to the screen's pixel format. Setting the bitmap to the 
            // screens pixel format can save many milliseconds in processing 
            // due to pixel size conversions otherwise required 
            Bitmap Bmp = new Bitmap(ParentBorder.Width, ParentBorder.Height, Graphics.FromHwnd(IntPtr.Zero));
            // Next we create a graphics object tied to our bitmap for 
            // drawing our rectangles within a defined border
            Graphics BmpGfx = Graphics.FromImage(Bmp);
           
            //
            // Draw your rectangles here! A sample is below includes paintimg 
            // to the screen to illistrate this process
            //
            //
            // Rotate first rectangle 20 or transform as needed :)
            BmpGfx.RotateTransform(20);
            //
            // Sample 1: This one just shows a red rectangle near the center 
            // of the ParentBorder graphics object
            BmpGfx.DrawRectangle(new Pen(Color.Red), new Rectangle(new Point(100, -20), new Size(200, 200)));
            //
            // Reset back to normal transform
            BmpGfx.ResetTransform();
            //
            // Rotate second rectangle 60
            BmpGfx.RotateTransform(60);
            //
            // Sample 2: This one just shows a cropped blue rectangle at 
            // the borders
            BmpGfx.DrawRectangle(new Pen(Color.Blue), new Rectangle(new Point(145, -200), new Size(300, 300)));
            //
            // Reset back to normal transform for ddrawing a nice ParentBorder
            BmpGfx.ResetTransform();
            //
            // Border: This one just draws an Orange border around the ParaentBorder 
            // of the Bmp graphics object
            BmpGfx.DrawRectangle(new Pen(Color.Orange), new Rectangle(Point.Empty, new Size(Bmp.Width - 1, Bmp.Height - 1)));
            // Finally put your drawing to the screen. 50 points left and top so 
            // you can see the border and that nothing exceeds that ParaentBorder
            e.Graphics.DrawImage(Bmp, new Point(50,50));
            // Save your BMP to a file if you prefer or to "preserve the graphics" 
            // place the bmp in global scope (a global variable just don't forget 
            // to dispose when no longer needed)
            // Please dispose of your goods as variable objects not inline like 
            // done above to keep the GC happy of course. The below method ensures
            // resourses are fully released for imdediate cleanup by the GC. 
            Bmp.Dispose();
            Bmp = null;
            BmpGfx.Dispose();
            BmpGfx = null;
        }
