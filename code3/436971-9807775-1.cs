    System.Windows.Forms.Label label = new System.Windows.Forms.Label();
    label.Text = "Hallo";`
    label.MouseEnter += new EventHandler(label_MouseEnter);
    label.MouseWheel += new System.Windows.Forms.MouseEventHandler(label_MouseWheel);
    windowsFormsHost1.Child = label;
.....
    void label_MouseEnter(object sender, EventArgs e)
    {
        (sender as System.Windows.Forms.Label).Focus();
    }
    void label_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        (sender as System.Windows.Forms.Label).BackColor = System.Drawing.Color.Red;
    }
