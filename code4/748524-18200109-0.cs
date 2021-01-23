    TaskBar.MouseDown += new MouseEventHandler(this.taskbar_MouseDown);
    private void taskbar_MouseDown(object sender, MouseEventArgs e)
    {
        // Determine which mouse button is clicked. 
        if(e.Button == MouseButtons.Middle)
        {
            MessageBox.Show("Middle");
        }
    }
