    private void treeView_NodeMouseHover(object sender,
                                         TreeNodeMouseHoverEventArgs e)
    {
        timer.Stop();
        toolTip.Hide(this);
        toolTipNode = e.Node;
        timer.Interval = InitialToolTipDelay;
        timer.Start();
    }
