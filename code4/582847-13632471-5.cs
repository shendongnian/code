    picBoxs[i].Click += new System.EventHandler(Boxes_Click);
    picBoxs[i].Coordinates = new Point(x,y);
    picBoxs[i].Position = new Point(x * size_w, y*size_h);
    picBoxs[i].Size = new Size(size_w, size_h);
... 
    void Boxes_Click(object sender, EventArgs e)
    {
        MyPictureBox theBox = sender as MyPictureBox;
        if(theBox != null)
        {
         MessageBox.Show("Box was clicked, x: {0} y:{1}", 
                         theBox.Coordinates.X, 
                         theBox.Coordinates.Y);
        } 
    } 
