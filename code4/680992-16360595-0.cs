    public GUI(frmMain frm) {
      assignEvents(frm.Controls);
    }
    public void assignEvents(Control.ControlCollection controls) {
      foreach (Control ctl in controls) {
        ctl.BackColor = Color.GreenYellow;
        assignEvents(ctl.Controls);
      }
    }
