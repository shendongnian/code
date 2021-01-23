    private void sprites_updater_Tick(object sender, EventArgs e)
    {
        s++;
        int x = player.Location.X;
        int y = player.Location.Y;
        if (s == 1)
        if (isAPressed)
            {
                player.Location = new Point(x - 5, y);
            }
            s = 0;
            sprites_updater.Start();
        }
