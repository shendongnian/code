        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e. (ModifierKeys & Keys.None) == Keys.None)
            {
                MessageBox.Show("No key was held down.");
            }
        }
