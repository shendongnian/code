    // InitializeComponent        
    this.timercheckbox.Interval = 5000;
    this.timercheckbox.Tick += new System.EventHandler(this.timercheckbox_Tick);
    private void timercheckbox_Tick(object sender, EventArgs e)
    {
        checkBoxWMVFile.Checked = false;
        checkBoxWMVFile.Checked = true;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if( timercheckbox.Enabled == true )
        {            
            timercheckbox.Enabled = false;
            button1.Text = "Start Auto save";
        }
        else
        {
            timercheckbox.Interval = (int)numericChnageTime.Value;
            timercheckbox.Enabled = true;
            checkBoxWMVFile.Checked = true;
            button1.Text = "Stop Auto save";
        }
    }
