        private readonly List<Control> controlsToReEnable = new List<Control>() ;
        private void Form1_Activated(object sender, EventArgs e)
        {
            foreach (var control in controlsToReEnable)
            {
                control.Enabled = true;
            }
        }
        
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            controlsToReEnable.Clear();
            foreach (var control in this.Controls)
            {
                var titi = control as Control;
                if (titi != null && titi.Enabled)
                {
                   titi.Enabled = false;//Disable every controls that are enabled
                   controlsToReEnable.Add(titi);  //Add it to the list to re-Enable it after
                }
            }
        }
