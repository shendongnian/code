    public override bool Visible
            {
                get
                {
                    return base.Text;
                }
                set
                {
                    base.Text = value;
                    // Insert my code
                    if (frmDLg != null && !frmDLg.IsDisposed)
                    {
                        frmDLg.TopMost = this.Visible;
                    }
                }
            }
