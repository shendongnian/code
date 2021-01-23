    public void draw(ref Panel inputPanel) //draws the eventline
    {
        int stepCounter = 0;
        for (int i = 0; i < DaysList.Count-1; i++)
        {
            Button b1;
            if (DaysList[i].Elements.Count > max)
            {
                b1 = new Button(); //Create the box
                b1.Width = 120;
                b1.Height = 40; //Set width and height
                b1.Location = new Point(stepCounter + 35, 70); //Location
                inputPanel.Controls.Add(b1); //
                b1.Text = "Check event date in grid";
                b1.Show();
                b1.BringToFront();
                b1.Tag = DaysList[i].Elements;
                b1.Click += btn_Click;
                stepCounter += 200;
            }
         }
     } 
