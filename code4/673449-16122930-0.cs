    private bool dgvInitialized = false;
    
    private void dgvTest_VisibleChanged(object sender, EventArgs e)
    {
        if (dgvTest.Visible && !dgvInitialized)
        {
            dgvInitialized = true;
    
            // Move Form1_Load code to here instead...
        }
    }
