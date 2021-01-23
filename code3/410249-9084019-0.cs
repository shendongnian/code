    public static void GetAreasAndLengthsAsync(Shape shape, Action<SomeResult> callback)
    {
        var geometryService = new GeometryService();
        geometryService.AreasAndLengthsCompleted += (s, e) =>
        {
            if (callback != null)
            {
                callback(e.SomeResult);
            }
        };
        geometryService.AreasAndLengthsAsync(shape);
    }
