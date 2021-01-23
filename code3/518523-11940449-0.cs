    Dictionary<Color, List<Rectangle>> rectangles = new Dictionary<Color, List<Rectangle>>();
    
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        //The key value for the dictionary is the color to use to paint with, so loop through all the keys (colors)
        foreach (var rectKey in rectangles.Keys)
        {
            using (var pen = new Pen(rectKey))     //Create the pen used to draw the rectangle (using statement makes sure the pen is disposed)
            {
                //Draws all rectangles for the current color
                //Note that we're using the Graphics object that is passed into the event handler.
                e.Graphics.DrawRectangles(pen, rectangles[rectKey].ToArray());                    
            }
        }
    }
    
    //This method just adds the rectangle to the collection.
    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            Color c = getSelectedColor();     //Gets a color for which to draw the rectangle
    
            //Adds the rectangle using the color as the key for the dictionary
            if (!rectangles.ContainsKey(c))   
            {
                rectangles.Add(c, new List<Rectangle>());
            }
            rectangles[c].Add(new Rectangle(e.Location.X - 12, e.Location.Y - 12, 25, 25));    //Adds the rectangle to the collection
        }
    
        //Make the panel repaint itself.
        panel1.Refresh();
    }
