    msRect = ms;
    foreach (Plant NewPlant in plants) // no need for indexes
    {
        if (NewPlant.BoundingBox.Intersects(msRect))
        {
            SelectedPlant = NewPlant; // this is everything you need
            NewPlant.Tint = Color.Black;
        }
        else
            NewPlant.Tint = Color.White;
    }
