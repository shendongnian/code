    private bool toolTipShown = false;
    private void Control_MouseMove(object sender, MouseEventArgs e)
    {
        var parent = sender as Control;
        if (parent == null)
        {
            return;
        }
        var ctrl = parent.GetChildAtPoint(e.Location);
        if (ctrl != null)
        {
            if (ctrl.Visible && toolTip1.Tag == null)
            {
                if (!toolTipShown)
                {
                    var tipstring = toolTip1.GetToolTip(ctrl);
                    toolTip1.Show(tipstring.Trim(), ctrl, ctrl.Width / 2, ctrl.Height / 2);
                    toolTip1.Tag = ctrl;
                    toolTipShown = true;
                }
            }
        }
        else
        {
            ctrl = toolTip1.Tag as Control;
            if (ctrl != null)
            {
                toolTip1.Hide(ctrl);
                toolTip1.Tag = null;
                toolTipShown = false;
            }
        }
    }
