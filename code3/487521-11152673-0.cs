        SlowForm _slowForm;
        private void openSlowLoadingWindow()
        {
            _slowForm = new SlowForm();
            System.Windows.Forms.Application.Run(_slowForm);
        }
        private void btnSlowForm_Click(object sender, EventArgs e)
        {
            _slowForm.ShowFromThread();
            Hide();
        }
