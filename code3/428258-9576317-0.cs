    for (int i = 0; i < list.Count; i++)
    {
        list[i].Update(); // If the update is made at the same place
        if (list[i].Removed) // A flag that indicates the sprite should be removed
        {
            list.Remove(i);
            i--;
        }
    }
