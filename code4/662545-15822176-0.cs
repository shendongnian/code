    Point[] listOfNodes = new Point[1];
    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        foreach (Point item in listOfNodes)
        {
            if (item == e.Location)
            {
                //The node was clicked.
            }
        }
    }
