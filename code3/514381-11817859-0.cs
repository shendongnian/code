    int xPos = 10;
    int yPos = 36;
    // Add 10 progressbars to the groupbox control collection
    for(x = 0; x < 10; x++)
    {
        yPos = yPos + (x * 30);
        ProgressBar progressBar1 = new ProgressBar(); 
        progressBar1.Name = "pgb" + x.ToString();
        progressBar1.Size = new System.Drawing.Size(516, 23); 
        progressBar1.Location = new Point(10, yPos); 
        groupBox4.Controls.Add(progressBar1); 
    }
