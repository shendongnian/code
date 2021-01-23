    public static Color ForeColorChange(this Control owned, bool changed) {
      if (owned is TextBox) {
        return changed ? Color.Red : SystemColors.WindowText;
      } else {
        return changed ? Color.Red : SystemColors.ControlText;
      }
    }
    
    public static Color BackColorChange(this Control owned, bool changed) {
      if (owned is TextBox) {
        return changed ? Color.Yellow : SystemColors.Window;
      } else {
        return SystemColors.Control;
      }
    }
