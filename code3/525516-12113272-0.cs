    public static void ForeColorChange(this Control owned, bool changed) {
      if (owned is TextBox) {
        owned.ForeColor = changed ? Color.Red : SystemColors.WindowText;
      } else {
        owned.ForeColor = changed ? Color.Red : SystemColors.ControlText;
      }
    }
    public static Color BackColorChange(this Control owned, bool changed) {
      if (owned is TextBox) {
        owned.BackColor = changed ? Color.Yellow : SystemColors.Window;
      } else {
        owned.BackColor =  SystemColors.Control;
      }
    }
