    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
        Form child = this.ActiveMdiChild;
        if (child != null)
        {
            DialogResult res = 
                MessageBox.Show( child.Name +
                "Do you want to exit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
                child.Focus();
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
