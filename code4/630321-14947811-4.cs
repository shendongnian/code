        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.None) == Keys.None)
            {
                MessageBox.Show("No key was held down.");
            }
        }
