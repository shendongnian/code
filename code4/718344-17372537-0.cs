    private void redLabel_MouseClick(object sender, MouseEventArgs e)
    {
       // Fired whenever the control is clicked; e.Location gives the location of
       // the mouse click in client coordinates.
       Debug.WriteLine("The control was clicked at " + e.Location);
    }
