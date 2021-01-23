        MouseEventArgs args = (MouseEventaArgs) e;  
        DataGridView.HitTestInfo hitTest = this.grid.HitTest(args.X, args.Y);
        if (hitTest.Type == DataGridViewHitTestType.Cell)
        {
             DataGridViewCell cell = (DataGridViewCell)this.Grid[hitText.ColumnIndex, hitTest.RowIndex];
             // execute business logic here
        }
