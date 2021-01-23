    MyMap.MouseClick += (s, e) =>
    {
        var queryTask = new QueryTask(URL);
        var query = new Query
        {
            Geometry = e.Point,
            OutSpatialReference = MyMap.SpatialReference,
            ReturnGeometry = true
        };
        query.OutFields.Add("*");
        queryTask.ExecuteCompleted += .. Some Completed Handler ..
        queryTask.Failed += .. Some Failed Handler ..
        queryTask.ExecuteAsync(query);
    }
