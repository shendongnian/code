            Point locationOnForm = AnyObject.FindForm().PointToClient(AnyObject.Parent.PointToScreen(AnyObject.Location));
            lblQue.Text = "Text to be shown";
            panel8.Location = new Point(locationOnForm.X, locationOnForm.Y+27);
            panel8.Size = new Size(470, 30);
            panel8.BackColor = Color.SkyBlue;
            this.Controls.Add(panel8);
            panel8.BringToFront();
            panel8.Show();
