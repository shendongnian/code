    public class GrayingOutForm : Form
    {
        public GrayingOutForm()
        {
            this.Activated += this.Form1_Activated;
            this.Deactivate += this.Form1_Deactivate;
        }
        private readonly List<Control> _controlsToReEnable = new List<Control>() ;
        private void Form1_Activated(object sender, EventArgs e)
        {
            foreach (var control in _controlsToReEnable)
                control.Enabled = true;
            
        }
        
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            _controlsToReEnable.Clear();
            foreach (var control in this.Controls)
            {
                var titi = control as Control;
                if (titi != null && titi.Enabled)
                {
                   titi.Enabled = false;//Disable every controls that are enabled
                   _controlsToReEnable.Add(titi);  //Add it to the list to reEnable it after
                }
            }
        }
    }
