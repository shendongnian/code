    var targetURL = // ...
    
    try
    {
        SuspendLayout();
    
        for (int i = 0; i < 10; i++)
        {
            var button = new Button();
            button.Text = String.Format("Button {0}", i);
            button.Location = new Point(0, i * 25);
            button.Click += (object sender, EventArgs e) => System.Diagnostics.Process.Start(targetURL);
            this.Controls.Add(button);
        }
    }
    finally
    {
        ResumeLayout();
    }
