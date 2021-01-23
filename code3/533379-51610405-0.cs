    public static bool Valid(this ErrorProvider ep)
    {
      ep.ContainerControl.ValidateChildren();
      return ep.ChildrenAreValid(ep.ContainerControl);
    }
    private static bool ChildrenAreValid(this ErrorProvider ep, Control control)
    {
      if (!string.IsNullOrWhiteSpace(ep.GetError(control))) return false;
      foreach (Control c in control.Controls)
        if (!(ep.ChildrenAreValid(c))) return false;
      return true;
    }
