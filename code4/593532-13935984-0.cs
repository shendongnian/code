    private static void SetAllParentVisibility(bool visible, Control ctrl)
    {
        ctrl.Visible = visible;
        if (ctrl.Parent != null)
            SetAllParentVisibility(visible, ctrl.Parent);
    }
