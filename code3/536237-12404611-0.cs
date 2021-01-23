        void ClearControls(Control parent)
        {
            while (parent.Controls != null && parent.Controls.Count > 0)
            {
                ClearControls(parent.Controls[0]);
                parent.Controls.Remove(parent.Controls[0]);
            }
        }
