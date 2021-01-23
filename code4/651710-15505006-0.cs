        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad1:
                case Key.D1:
                    addInput('1');
                    MyTextBox.Focus(); // <-- NEW LINE OF CODE
                    break;
                case Key.Return:
                    MessageBox.Show("Enter!");
                    MyTextBox.Focus(); // <-- NEW LINE OF CODE
                    break;
            }
        }
