    Label[] lblLeftUp = new Label[12];
    int PointX = 100; //100 is the initial distance from the left border of the control
    for (int i = 0; i < 12; i++)
    {
       lblLeftUp[i] = new Label();
       lblLeftUp[i].Location = new Point(PointX, 100);
       lblLeftUp[i].Text = Convert.ToString(i + 1);
       this.Controls.Add(lblLeftUp[i]);
       PointX += lblLeftUp[i].Width;
    }
   
