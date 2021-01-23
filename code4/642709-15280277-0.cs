    public bool g_RecalcCursor = false;
    public Point g_Reference = new Point(400,400);
    public void SceneView_MouseMove(object sender, MouseEventArgs e)
    {
        // this logic avoids recursive calls into MouseMove
        if (g_RecalcCursor)
        { 
            g_RecalcCursor = false;
            return;
        }
        Point ee = (sender as PictureBox).PointToScreen(e.Location);
        Point delta = new Point(g_Reference.X - ee.X, g_Reference.Y - ee.Y);
        //------------------------------------------//
        // I can use delta now to move my cursor    //
        // and apply logic "BEFORE" it renders      //
        //------------------------------------------//
        g_RecalcCursor = true;
        Cursor.Position = g_Reference;
    }
