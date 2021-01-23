        private void btnSayHello_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!");
        }
        private void btnTriggerHello_Click(object sender, EventArgs e)
        {
            btnSayHello_Click(null, null);
        }
