    public class ControlColorizer
    {
        private Color _setBColor = SystemColors.Window;
    
        public ControlColor(Color bkg, params Control[] ctls)
        {
            _setBColor = bkg;
            foreach (Control o in ctls)
            {
                o.Enter += new EventHandler(o_Enter);
                o.Leave += new EventHandler(o_Leave);
            }
        }
    
        private void o_Enter(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                Control c = (Control)sender;
                c.BackColor = _setBColor;
            }
    
        }
        private void o_Leave(object sender, EventArgs e)
        {
            Control c = sender as Control;
            c.BackColor = SystemColors.Window;
        }
