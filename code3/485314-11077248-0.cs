    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        {
            if (mouseMove == true)
            {
                Point NewPoint = e.Location;
                if (!((PictureBox)sender).ClientRectangle.Contains(NewPoint))
                {
                    if (mouseLeave)
                    {
                        mouseMove = false;
                        return;
                    }
                }
                wireObject1.MovePoint(selectedIndex, NewPoint, NewPoint); // when moving a point dragging the other point is vanished deleted. To check why ! 
                label1.Text = "{X = " + NewPoint.X + "}" + " " + "{Y = " + NewPoint.Y + "}";
                pictureBox1.Refresh();
     
            }
            else
            {
                label19.Text = "{X = " + e.X + "}" + " " + "{Y = " + e.Y + "}";
            }
        } 
    }
