        public void LoadChildForm(Type childForm, Control container) {
            foreach (Control child in container.Controls) {
                if (child.GetType() == childForm) {
                    // Found it, bring to front
                    child.BringToFront();
                    return;
                }
            }
            // Doesn't exist yet, create a new instance
            Form xForm = (Form)Activator.CreateInstance(childForm);
            xForm.TopLevel = false;
            xForm.Visible = true;
            container.Controls.Add(xForm);
            xForm.BringToFront();
            // Show scrollbar
            xForm.AutoScrollMinSize = new Size(0, 2000);
        }
    }
