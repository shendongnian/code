Point originallocation = this.Location;
Size originalsize = this.Size;
public void RemoveBorder(IntPtr windowHandle, bool removeBorder)
{
    uint currentstyle = (uint)GetWindowLongPtr(this.Handle, GWL_STYLE).ToInt64();
    uint[] styles = new uint[] { WS_CAPTION, WS_THICKFRAME, WS_MINIMIZE, WS_MAXIMIZE, WS_SYSMENU };
    foreach (uint style in styles)
    {
    
        if ((currentstyle & style) != 0)
        {
        
            if(removeBorder)
            {
            
                currentstyle &= ~style;
            }
            else
            {
            
                currentstyle |= style;
            }
        }
    }
    SetWindowLongPtr(windowHandle, GWL_STYLE, (IntPtr)(currentstyle));
    //this resizes the window to the client area and back. Also forces the window to redraw.
    if(removeBorder)
    {
    
        SetWindowPosPtr(this.Handle, (IntPtr)0, this.PointToScreen(this.ClientRectangle.Location).X, this.PointToScreen(this.ClientRectangle.Location).Y, this.ClientRectangle.Width, this.ClientRectangle.Height, 0);
    }
    else
    {
    
        SetWindowPosPtr(this.Handle, (IntPtr)0, originallocation.X, originallocation.Y, originalsize.Width, originalsize.Height, 0);
    }
}
