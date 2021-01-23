    protected override void OnDragLeave(System.Windows.DragEventArgs e)
    {
        if (!this.IsSelected)
        {
            this.ClearValue(BackgroundProperty);
            this.ClearValue(BorderBrushProperty);
        }
        base.OnDragLeave(e);
    }
