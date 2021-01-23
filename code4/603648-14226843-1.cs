    private volatile bool isWorking = false;
    public void btm_Processing_Click(object sender, EventArgs e)
    {
        isWorking = true;
        for (int i = 1; i <= x ; i++)
        {
            //My Processing Commands are Here 
            if(!isWorking)
                break;
        }
    }
    private void btm_Stop_Click(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Do You Want To Stop Processing ? ", "Error", MessageBoxButtons.YesNo);
        isWorking = dialogResult != DialogResult.Yes;
    }
