    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        e.DrawBackground();
        if( e.State == DrawItemState.Focus )
            e.DrawFocusRectangle();
        var item = this.Items[e.Index];
        using(var brush = new SolidBrush(e.ForeColor))
        {
            e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds);
        }
        e.Graphics.DrawLine(SystemPens.ControlText, e.Bounds.X, e.Bounds.Y, e.Bounds.Right, e.Bounds.Y);
    
        base.OnDrawItem(e);
    }
