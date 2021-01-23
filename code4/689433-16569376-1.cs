      foreach(Control c in control.Controls) {
        if (c is TextBox) {
            if (!String.IsNullOrEmpty(((TextBox) c).Text)) {
                return false;
            }
        }
        else if (c.HasChildren) {
            if (IsThereDataInControl(c)) {
                return true;
            }
        }
    }
    return true;
