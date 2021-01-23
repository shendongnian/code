      foreach(Control c in control.Controls) {
        if (c is TextBox) {
            if (!String.IsNullOrEmpty(((TextBox) c).Text)) {
                return true;
            }
        }
        else if (c.HasChildren) {
            if (IsThereDataInControl(c)) {
                return true;
            }
        }
    }
    return false;
