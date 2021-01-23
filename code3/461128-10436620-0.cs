    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        if (clicked_once == false)
        {
            clicked_once = true;
            point1 = e.Location;
        }
        else if (clicked_once == true)
        {
            clicked_once = false;
            point2 = e.Location;
            int distance = Math.Abs(point1.X - point2.X);
            MessageBox.Show("Distance of pixels horizontally: " + distance.ToString());
        }
    }
