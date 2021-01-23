    public void Search(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.Controls.Count > 0)
                    Search(c);
                if (c is Label)
                    c.Visible = false;
            }
        }
