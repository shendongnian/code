    private void TabControl1_Selecting(Object sender, TabControlCancelEventArgs e) 
    {
        if (e.TabPage... /* Do check whether some of your special TabPages is being selected */)
        {
            e.Cancel = true;
            
            // All other TabPage-specific actions here
            ...
        }
    }
