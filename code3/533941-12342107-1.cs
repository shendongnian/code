    private bool CheckCollisionPoint(Point point, UIElement subTree)
    {
        var hits = VisualTreeHelper.FindElementsInHostCoordinates(point, subTree);
        return hits.Any(x => x != subTree);
    }
