    private void up_MouseDown(object sender, MouseEventArgs e)
    {
        while (P.Location.Y > 0)
        {
            P.Location = new System.Drawing.Point(P.Location.X, P.Location.Y - 1);
            System.Threading.Thread.Sleep(10);
        }
                 
    }
