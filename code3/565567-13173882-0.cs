    YourCustomControl uc = null;
    private void button1_Click(object sender, EventArgs e)
    {
         uc = new YourCustomControl();
         this.Controls.Add(uc); // this represent the user control in which yo want to add
                                // You can add it in some container like Panel or GroupBox
    }
