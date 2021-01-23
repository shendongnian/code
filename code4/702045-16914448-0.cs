    private int txtBoxStartPosition = 100;
    private int txtBoxStartPositionV = 25;
    
     for (int i = 0; i < 7; i++)
    {
        newLabel = new Label();
        newLabel.Location = new System.Drawing.Point(txtBoxStartPosition, txtBoxStartPositionV);
        newLabel.Size = new System.Drawing.Size(70, 40);
        newLabel.Text = i.ToString();
    
        panel1.Controls.Add(newLabel);
        txtBoxStartPositionV += 30;
    
    
    }
