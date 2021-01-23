    public bool checkcollision(Rectangle player)
    {
        for (int i = 0; i < 50; i++)
        {
            if (enemy[i].Contains(player.Left, player.Top)
                || enemy[i].Contains(player.Right, player.Top)
                || enemy[i].Contains(player.Left, player.Bottom)
                || enemy[i].Contains(player.Right, player.Bottom))
            {
                return true;
            }
        }
        return false;
    }
