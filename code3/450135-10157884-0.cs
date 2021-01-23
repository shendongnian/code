    msRect = ms;
    for (int i = 0; i < plants.Count; i++)
    {
        foreach (Plant NewPlant in plants) // <-- this is redundant
        {
            if (NewPlant.BoundingBox.Intersects(msRect))
            {
                SelectedIndex = i;
                NewPlant.Tint = Color.Black;
            }
            else
                NewPlant.Tint = Color.White;
        }
    }
