    private void CreateWindows()
    {
        newWindow = new Form();
        newWindow.Activate();
        newWindow.Size = new System.Drawing.Size(40, 40);
       Label label1 = new Label();
       label1.Text = "HI";
       label1.Visible = true;
       label1.Size = new System.Drawing.Size(24, 24);
       label1.Location = new System.Drawing.Point(24, 24);
       newWindow.Controls.Add(label1);  
       newWindow.Show();
       //use this if you want to wait for the form to be closed
       //newWindow.ShowDialog();
    }
