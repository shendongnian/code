    public static T FindControl<T>(string id, Control rootControl) where T : Control {
      if (rootControl == null)
        throw new ArgumentNullException("rootControl");
      var controls = new Stack<Control>();
      controls.Push(rootControl);
      while (controls.Count > 0) {
        var currentControl = controls.Pop();
        var typedControl = currentControl as T;
        if (typedControl != null && string.Compare(typedControl.ID, id, StringComparison.OrdinalIgnoreCase) == 0)
          return typedControl;
        foreach (Control childControl in currentControl.Controls) {
          controls.Push(childControl);
        }
      }
      return null;
    }
