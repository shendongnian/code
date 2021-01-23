    private void DrawPoint(int x, int y)
    {
    using (objGraphics = Graphics.FromImage(objBitmap))
    {
    objGraphics.DrawLine(APen, x, y, OldX, OldY);
    }
    
    Invalidate();
    }
