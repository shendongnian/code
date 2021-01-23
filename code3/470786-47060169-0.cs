      public bool show_scanning //turns on the scanning screen
        {
            set
            {
                scanning_pnl.Visible = true;
                notReady_pnl.Visible = false;
                timer1.Enabled = true;
            }
        }
