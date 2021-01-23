    private void CreateWindows()
    {
        newWindow = new Form();
        newWindow.Size = new System.Drawing.Size(40, 40);
        newWindow.Controls.Add
        (
            new Label()
            {
                Text = "HI",
                Visible = true,
                Size = new System.Drawing.Size(24, 24),
                Location = new System.Drawing.Point(24, 24)
            }
        );
        Application.Run(newWindow);
    }
