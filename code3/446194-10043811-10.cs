    void timer_Tick(object sender, EventArgs e)
    {
        timer.Stop();
        if (timer.Interval == InitialToolTipDelay) { 
            Point mousePos = treeView.PointToClient(MousePosition);
            // Show the ToolTip if the mouse is still over the same node.
            if (toolTipNode.Bounds.Contains(mousePos)) {
                 // Node location in treeView coordinates.
                Point loc = toolTipNode.Bounds.Location;
                 // Node location in form client coordinates.
                loc.Offset(treeView.Location);
                // Make balloon point to upper right corner of the node.
                loc.Offset(toolTipNode.Bounds.Width - 7, -12);
                toolTip.Show("Node: " + toolTipNode.Text, this, loc);
                timer.Interval = MaxToolTipDisplayTime;
                timer.Start();
            }
        } else {
            // Maximium ToolTip display time exceeded.
            toolTip.Hide(this);
        }
    }
