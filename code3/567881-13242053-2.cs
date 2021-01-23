        public void FindAllDockPanels(Control ctrl) {
        if (ctrl != null) {
            
            foreach (Control control in ctrl.Controls) {
                if (control is ASPxDockPanel) control.Controls.DelayedRemove( control );
            }
            control.Controls.DelayedRemoveFinish();
            
            FindAllDockPanels(control);
        }
    }
