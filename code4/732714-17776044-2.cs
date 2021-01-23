        Form2 f2 = new Form2();
        bool _Clickone = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!_Clickone)
            {
                _Clickone = true;
                f2.Show();
            }
            else
            {
                f2.WindowState = FormWindowState.Normal;
                f2.ShowInTaskbar = true;
                f2.BringToFront();
            }
        }
