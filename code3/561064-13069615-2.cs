        List<Int32> DrawPinRects;
        
        private void initBuffer()
        {
            DrawPinRects = new List<Int32>();
        }
        private void pinHover(Point Position)
        {
            DrawPinRects.Clear();
            for (int i = 0; i < pins.Count; i++)
            {
                if (isMouseOverPin(Position.X, Position.Y, pins[i]) == true)
                {
                    DrawPinRects.Add(i);
                }
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            pinHover(e.Location);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach(Int32 index in DrawPinRects)
            {
                Int32 y = panel1.VerticalScroll.Value + 10;
                e.Graphics.DrawRectangle(Pens.Black, 10, y, 10, 10);
            }
        }
