    private void ShowPanel(string panel)
        {
            foreach (Control c in Controls)
            {
                if (c is Panel)
                {
                    if (c.Name != "pnlBottom")
                    {
                        if (c.Name.Contains(panel))
                        {
                            c.Visible = true;
                            return;
                        }
                        else
                        {
                            c.Visible = false;
                        }
                    }
                }
            }
        }
