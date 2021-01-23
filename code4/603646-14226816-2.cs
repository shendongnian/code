    private volatile bool shouldStop = false;
    private void btm_Processing_Click(object sender, EventArgs e)
    {          
        for (int i = 1; i <= x ; i++)
        {
            //My Processing Commands are Here 
        
            if (shouldStop)
            {
                shouldStop=false;
                break;
            }
        }
    }
    private void btm_Stop_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Do you want to stop processing?",
                                           "Error",
                                           MessageBoxButtons.YesNo);
    
        if (dialogResult == DialogResult.Yes)
        {
            shouldStop = true;                
        }
        else
        {    
            // Do other things.
        }
    }
