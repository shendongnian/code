        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                MessageBox.Show("Control key was held down.");
            }
        }
