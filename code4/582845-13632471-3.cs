    void Boxes_Click(object sender, EventArgs e)
    {
        PictureBox theBox = sender as PictureBox;
        if(theBox != null)
        {
             
             MessageBox.Show("Box was clicked, x: {0} y:{1}", 
                             theBox.Location.X / BOX_SIZE, 
                             theBox.Location.Y / BOX_SIZE);
        } 
    } 
