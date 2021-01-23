        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.None) == Keys.None)
            {
                MessageBox.Show("No key was held down.");
            }
        }
