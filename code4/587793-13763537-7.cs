    private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if(SureClose())
        {
            SaveChanges();
        }
        else
        {
            e.Cancel = true; 
        }
    }
    
    private bool SureClose()
    {
        using(SureClose sc = new SureClose())
        {
            sc.StartPosition = FormStartPosition.CenterScreen;
            DialogResult result = sc.ShowDialog();
            if(result == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    protected virtual void SaveChanges()
    {
    }
