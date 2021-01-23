    public void FindAllDockPanels(Control ctrl) {
        if (ctrl != null) {
            List<Control> remove = new List<Control>();
            foreach (Control control in ctrl.Controls) {
                if (control is ASPxDockPanel) {
                    remove.Add( control );
                }
            }
            foreach(Control control in remove) {
                control.Controls.Remove( control );
                control.Dispose(); // do you really need to dispose of them?
            }
            FindAllDockPanels(control);
        }
    }
