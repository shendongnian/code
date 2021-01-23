    private processing _processingForm;
    
    private void submitButton_Click(object sender, EventArgs e)
    {
        _processingForm = new processing();
        _processingForm.MdiParent = this.ParentForm;
        _processingForm.StartPosition = FormStartPosition.CenterScreen;
        _processingForm.Show();
        this.Hide(); //HIDES THE CURRENT FORM CONTAINING SUBMIT BUTTON
    
        backgroundWorker1.RunWorkerAsync();
    }
