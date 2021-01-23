        private MouseButtons e_Button = new MouseButtons();
        private void dgv1_MouseDown(object sender, MouseEventArgs e)
        {
            e_Button = e.Button;
        }
        private void cms1_Opening(object sender, CancelEventArgs e)
        {
            if (e_Button == System.Windows.Forms.MouseButtons.Right)
                e.Cancel = true;
        }
