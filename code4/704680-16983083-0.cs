      protected T GetControlOfType<T>(Control root, string id) where T : Control {
        var stack = new Stack<Control>();
        stack.Push(root);
        while (stack.Count > 0) {
          var control = stack.Pop();
          var typedControl = control as T;
          if (typedControl != null && string.Compare(id, typedControl.ID, StringComparison.Ordinal) == 0) {
            return typedControl;
          }
          foreach (Control child in control.Controls) {
            stack.Push(child);
          }
        }
        return default(T);
      }
