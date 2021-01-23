    msRect = ms;
    for (int i = 0; i < plants.Count; i++)
    {
        Plant NewPlant = plants[i];
        if (NewPlant.BoundingBox.Intersects(msRect))
        {
            SelectedIndex = i;
            NewPlant.Tint = Color.Black;
        }
        else
            NewPlant.Tint = Color.White;
    }
