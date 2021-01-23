    public void openNextForm(Form f1, Form f2)
        {
            // we don't need ownership since f1 is hidden.                
            // f2.Owner = f1; 
            f2.WindowState = FormWindowState.Maximized;
            // we don't need this event handled since we use ShowDialog
            //f2.FormClosing += new FormClosingEventHandler(f_FormClosing);
            // The following should hide f1 after f2 is displayed even when using dialog
            f2.Shown += (s, e) => {
                f1.Hide();
            };
            f2.ShowDialog();
            f1.Show();
        }
