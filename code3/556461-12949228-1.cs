    void drawRectangles(Graphics g, List<Rectangle> list) {
        if (list.Count == 0) {
            return;
        }
        Rectangle lastRect = list[0];
        g.DrawRectangle(Pens.Black, lastRect);
        // Indexing from the second rectangle -- the first one is already drawn!
        for (int i = 1; i < list.Count; i++) {
            Rectangle newRect = list[i];
            g.DrawLine(Pens.AliceBlue, new Point(lastRect.Right, lastRect.Bottom), new Point(newRect.Left, newRect.Top));
            g.DrawRectangle(Pens.Black, newRect);
            lastRect = newRect;
        }
    }
