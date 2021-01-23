        bool IsCancelBtnClicked=false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsCancelBtnClicked=true;
            this.Close();
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel=!IsCancelBtnClicked;
        }
