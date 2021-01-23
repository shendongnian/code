    #region " content "
    using (GraphicsPath bb = CreateRoundRectangle(rect, 2))
    {
        //int opacity = pressed ? 0xcc : 0x7f;
        int opacity = 255;
        using (Brush br = new SolidBrush(Color.FromArgb(opacity, backColor)))
        {
            g.FillPath(br, bb);
        }
    }
    #endregion
