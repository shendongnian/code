    [Invoke]
    public void MarkAllPointAsFavourite(Guid userId, List<int> pointIds)
    {
        PointRepository.MarkAllPointAsFavourite(userId, pointIds);
    }
