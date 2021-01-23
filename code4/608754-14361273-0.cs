    void control_MouseClick(object sender, MouseEventArgs e)
    {
        //get mouse point relative to panel
        var mousePoint = panelMain.PointToClient(Cursor.Position);
        int startX = mousePoint.X;
        int startY = mousePoint.Y;
        //store the best match as we find them
        ClickControl selected = null;
        double? closestDistance = null;
        //loop all controls to find the best match
        foreach (Control c in panelMain.Controls)
        {
            ClickControl control = c as ClickControl;
            if (control != null)
            {
                //calculate the center point of the control relative to the parent panel
                int endX = control.Location.X + (control.Width / 2);
                int endY = control.Location.Y + (control.Height / 2);
                //calculate the distance between the center point and the mouse point
                double distance = Math.Sqrt(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2));
                //if this one is closer then we store this as our best match and look for the next best match
                if (closestDistance == null || closestDistance > distance)
                {
                    selected = control;
                    closestDistance = distance;
                }
            }
        }
    
        //`selected` is now the correct control
    }
