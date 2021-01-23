        private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        { 
            //Check for Tab key
            if (e.KeyCode == Keys.Tab)
            {
               //Do something
            }
            //Check for the Shift Key as well
            if (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Tab) {
                //Other stuff to do
            }
        }
