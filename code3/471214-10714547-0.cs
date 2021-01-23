    Color[] colors = new Color[] { Color.Red, Color.Green, Color.Wheat, Color.Gray. Color.Black,  Color.Blue};
    foreach (Series series in chrtTickets.Series)
    {
        foreach (DataPoint point in series.Points)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 5);
            point.LabelBackColor = colors[ randomNumber];
        }
    }
