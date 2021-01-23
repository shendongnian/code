    protected override void WndProc(ref Message m)
    {
       const int WM_NOTIFY    = 0x004E;
       const int EN_LINK      = 0x070B;
       const int WM_SETCURSOR = 0x0020;
    
       if (m.Msg == WM_NOTIFY)
       {
          NMHDR nmhdr = (NMHDR)m.GetLParam(typeof(NMHDR));
          if (nmhdr.code == EN_LINK)
          {
             ENLINK enlink = (ENLINK)m.GetLParam(typeof(ENLINK));
             if (enlink.msg == WM_SETCURSOR)
             {
                // Get the position of the last line of text in the RichTextBox.
                Point ptLastLine = rtb.GetPositionFromCharIndex(rtb.TextLength);
    
                // That point was in client coordinates, so convert it to
                // screen coordinates so that we can match it against the
                // position of the mouse pointer.
                ptLastLine = rtb.PointToScreen(ptLastLine);
    
                // Determine the height of a line of text in the RichTextBox.
                // 
                // For this simple demo, it doesn't matter which line we use for
                // this since they all use the same size and style. However, you
                // cannot generally rely on this being the case.
                Size szTextLine = TextRenderer.MeasureText(rtb.Lines[0], rtb.Font);
    
                // Then add that text height to the vertical position of the
                // last line of text in the RichTextBox.
                ptLastLine.Y += szTextLine.Height;
    
                // Now that we know the maximum height of all lines of text in the
                // RichTextBox, we can compare that to the pointer position.
                if (Cursor.Position.Y > ptLastLine.Y)
                {
                   // If the mouse pointer is beyond the last line of text,
                   // do not treat it as a hyperlink.
                   m.Result = (IntPtr)1;
                   return;
                }
             }
          }
       }
       base.WndProc(ref m);
    }
