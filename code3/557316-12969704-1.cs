    foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button)
                    {
                        ctrl.Enabled = true;
                    }
                }
