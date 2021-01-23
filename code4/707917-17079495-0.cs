    protected void UpdateExtendedStyles()
    {
        if (base.IsHandleCreated)
        {
            int lparam = 0;
            int wparam = 0x10cfd;
            switch (this.activation)
            {
                case ItemActivation.OneClick:
                    lparam |= 0x40;
                    break;
    
                case ItemActivation.TwoClick:
                    lparam |= 0x80;
                    break;
            }
            if (this.AllowColumnReorder)
            {
                lparam |= 0x10;
            }
            if (this.CheckBoxes)
            {
                lparam |= 4;
            }
            if (this.DoubleBuffered)
            {
                lparam |= 0x10000;
            }
            if (this.FullRowSelect)
            {
                lparam |= 0x20;
            }
            if (this.GridLines)
            {
                lparam |= 1;
            }
            if (this.HoverSelection)
            {
                lparam |= 8;
            }
            if (this.HotTracking)
            {
                lparam |= 0x800;
            }
            if (this.ShowItemToolTips)
            {
                lparam |= 0x400;
            }
            base.SendMessage(0x1036, wparam, lparam);
            base.Invalidate();
        }
    }
