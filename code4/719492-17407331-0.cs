        private static void FindControlsRecursively(Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                if (ctrl is DataGridView)
                    ((Label)ctrl).ReadOnly = true;
                else if (ctrl.Controls.Count > 0)
                    FindControlsRecursively(ctrl.Controls);
            }
        }
