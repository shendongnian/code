    private void comment_btn_Click(object sender, EventArgs e)
    {
        foreach(Control control in show_pnl.Controls)
        {
            TimeRecordingControl timeRecordingControl = control as TimeRecordingControl;
            if(timeRecordingControl != null)
            {
                timeRecordingControl.Textbox();
            }
        }
    }
