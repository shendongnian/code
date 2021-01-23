    for (int i = levelObjectsCount - 1; i >= 0; i--)
    {
        if (levelObjects[i].BoundingBox.Intersects(mouseBlock.BoundingBox))
        {
            levelObjects.RemoveAt(i);
        }
    }
