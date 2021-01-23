    private void FocusOnNextVisibleControl(Control currentControl)
    {
        Form form = currentControl.FindForm();
        Control nextControl = form.GetNextControl(currentControl, true);
        while (nextControl != null && !nextControl.Visible && nextControl != currentControl)
        {
            nextControl = form.GetNextControl(nextControl, true);
        }
        if (nextControl != null && nextControl.Visible)
        {
            nextControl.Focus();
        }
    }
