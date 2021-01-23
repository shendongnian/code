    private void CreateWindows()
    {
        newWindow = new Form();
        //Application.Run(newWindow); //Not here
        //newWindow.Activate(); //Wont do anything
        newWindow.Size = new System.Drawing.Size(40, 40);
        Label label1 = new Label();
        newWindow.Controls.Add(label1); //Good
        label1.Text = "HI";
        label1.Visible = true;
        label1.Size = new System.Drawing.Size(24, 24);
        label1.Location = new System.Drawing.Point(24, 24);
       
        Application.Run(newWindow); //Here instead
    }
