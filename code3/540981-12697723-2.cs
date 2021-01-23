    private void thumbFlow_DragDrop(object sender, DragEventArgs e)
    {
        FlowLayoutPanel _destination = (FlowLayoutPanel)sender;
        Point p = _destination.PointToClient(new Point(e.X, e.Y));
        var item = _destination.GetChildAtPoint(p);
        if (item == null)
        {
            p.Y = p.Y - 10;
            item = _destination.GetChildAtPoint(p);
        }
        int dropIndexValue = _destination.Controls.GetChildIndex(item, false);
        if (dropIndexValue < 0)
            return;
        //**************************************************//
        //**  Process multiple Select Drag / Drop   
        //**    If Drag From > Drag To, move after.
        //**    If Drag From < Drag To, move before.
        //**************************************************//
        //** First .. Find all items that are selected **//
        Boolean WasDragUp = false;
        int? firstDragIndexValue = null;
        int newIndexVal = dropIndexValue;
        foreach (PictureBox thumbFrame in thumbFlow.Controls.OfType<PictureBox>().Where(selVal => selVal.IsSelected))
        {
            if (firstDragIndexValue == null)
            {
                firstDragIndexValue = _destination.Controls.GetChildIndex(thumbFrame, false);
                if (firstDragIndexValue > dropIndexValue)
                    WasDragUp = true;
            }
            thumbFrame.pageIndex = newIndexVal;
            newIndexVal++;
        }
        //** Second .. Find all items that are NOT selected **//
        if (WasDragUp)
        {
            newIndexVal = 0;
            foreach (PictureBox thumbFrame in thumbFlow.Controls.OfType<PictureBox>().Where(selVal => !selVal.IsSelected))
            {
                if (_destination.Controls.GetChildIndex(thumbFrame, false) == dropIndexValue)
                    if (newIndexVal <= dropIndexValue)
                        newIndexVal = dropIndexValue + getThumbSelectedCnt();
                thumbFrame.pageIndex = newIndexVal;
                newIndexVal++;
            }
        }
        else
        {
            newIndexVal = 0;
            foreach (PictureBox thumbFrame in thumbFlow.Controls.OfType<PictureBox>().Where(selVal => !selVal.IsSelected))
            {
                thumbFrame.pageIndex = newIndexVal;
                if (_destination.Controls.GetChildIndex(thumbFrame, false) == dropIndexValue)
                {
                    newIndexVal = dropIndexValue + getThumbSelectedCnt();
                }
                newIndexVal++;
            }
        }
        //** Third .. Set the Child Index value  **//
        newIndexVal = 0;
        foreach (PictureBox thumbFrame in thumbFlow.Controls.OfType<PictureBox>().OrderBy(si => si.pageIndex))
        {
            thumbFrame.pageIndex = newIndexVal;
            _destination.Controls.SetChildIndex(thumbFrame, thumbFrame.pageIndex);
            thumbFrame.IsSelected = false;
            newIndexVal++;
        }
        //** Finally, rebuild the screen  **//
        _destination.Invalidate();
    }
    private void thumbFlow_DragEnter(object sender, DragEventArgs e)
    {
        //apply/clear highlight
        foreach (PictureBox thumbFrame in thumbFlow.Controls.OfType<PictureBox>())
        {
            if (thumbFrame == ActiveControl)
            {
                thumbFrame.IsSelected = true;
            }
        }
        e.Effect = DragDropEffects.Move;
        if (dragDropOccurred == false)
        {
            dragDropOccurred = true;
        }
    }
    /// <summary>
    /// Scroll when user drags above or below the window object.
    /// </summary>
    private void thumbFlow_DragLeave(object sender, EventArgs e)
    {
        int BegY_ThumbFlow = this.thumbFlow.FindForm().PointToClient(this.thumbFlow.Parent.PointToScreen(this.thumbFlow.Location)).Y;
        int thumbFlowBound_Y = this.thumbFlow.Height + BegY_ThumbFlow;
        int mouseY = this.thumbFlow.FindForm().PointToClient(MousePosition).Y;
        while (mouseY >= thumbFlowBound_Y)
        {
            thumbFlow.VerticalScroll.Value = thumbFlow.VerticalScroll.Value + DRAG_DROP_SCROLL_AMT;
            mouseY = thumbFlow.FindForm().PointToClient(MousePosition).Y;
            thumbFlow.Refresh();
        }
        while (mouseY <= BegY_ThumbFlow)
        {
            thumbFlow.VerticalScroll.Value = thumbFlow.VerticalScroll.Value - DRAG_DROP_SCROLL_AMT;
            mouseY = thumbFlow.FindForm().PointToClient(MousePosition).Y;
            thumbFlow.Refresh();
        }
    }
