    FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();
    void LoadControls()
    {
        UserControl[] u= new UserControl[20];
        for (int j = 0; j < 20; j++) 
        {
            u[j] = new UserControl();               
            u[j].BringToFront();
            flowLayoutPanel1.Controls.Add(u[j]);
            u[j].Visible = true;
            u[j].button1.Click +=new EventHandler(sad);
        }
    }
    private void sad(object sender, EventArgs e)
    { 
        Control c = (Control)sender;
        //returns the parent Control of the sender button
        //Could be useful 
        UserControl parent = (UserControl)c.Parent;  //Cast to appropriate type
        //Check if is a button
        if (c.GetType() == typeof(Button))
        {
            if (c.Name == <nameofSomeControl>) // Returns name of control if needed for checking
            {
                //Do Something
            }
        }
        //Check if is a Picturebox
        else if (c.GetType() == typeof(PictureBox))
        {
        }
        //etc. etc. etc      
    }
