    protected override void OnKeyPress(KeyPressEventArgs e) {
      if (!IsCurrentCellInEditMode) {
        BeginEdit(true);
        SendKeys.Send(e.KeyChar.ToString());
      }
      base.OnKeyPress(e);
    }
