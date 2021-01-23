    foreach (var obj in levelObjects.ToList())
    {
        if (obj.BoundingBox.Intersects(mouseBlock.BoundingBox))
        {
            levelObjects.Remove(obj);
        }
    }
