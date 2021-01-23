    public class ButtonTimer : CheckBox
    {
        private System.Windows.Forms.Timer Tmr = new System.Windows.Forms.Timer();
        private System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
        public ButtonTimer()
        {
            this.Tmr.Interval = 500;
            this.Tmr.Tick += new EventHandler(tmr_Tick);
            this.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckedChanged += new EventHandler(ButtonTimer_CheckedChanged);
            ContextMenuStrip cms = new ContextMenuStrip();
            ToolStripItem tsi = cms.Items.Add("Reset");
            tsi.Click += new EventHandler(tsi_Click);
            this.ContextMenuStrip = cms;
        }
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            this.Text = TimeSpan.Zero.ToString(@"hh\:mm\:ss");
        }
        private void ButtonTimer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Checked)
            {
                this.SW.Start();
                this.Tmr.Start();
            }
            else
            {
                this.SW.Stop();
                this.Tmr.Stop();
            }
        }
        private void tmr_Tick(object sender, EventArgs e)
        {
            this.UpdateTime();
        }
        private void UpdateTime()
        {
            this.Text = this.SW.Elapsed.ToString(@"hh\:mm\:ss");
        }
        private void tsi_Click(object sender, EventArgs e)
        {
            if (this.SW.IsRunning)
            {
                SW.Restart();
            }
            else
            {
                SW.Reset();
            }
            this.UpdateTime();
        }
    }
