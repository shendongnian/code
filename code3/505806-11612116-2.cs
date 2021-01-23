    foreach(TouchLocation tl in touchCollection)
    {
        if(tl.State == TouchLocationState.Moved) // Moved? Is that right?
        {
            foreach(Planet planet in planets)
            {
                // Alternately: if(GetPlanetRectangle(planet).Contains(...))
                if(planet.Bounds.Contains((int)tl.Position.X, (int)tl.Position.Y))
                {
                    // Do stuff...
                }
            }
        }
    }
