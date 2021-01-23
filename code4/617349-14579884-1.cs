       private void Form_KeyUp(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.L && e.Control)
           {
                    yourButton.PerformClick();
                    e.Handled = true;
            }
        }
