    DbGeometry myGeometry = DbGeometry.FromText("POLYGON ((10 10, 15 15, 5 15, 10 15, 10 10))");
    if(!myGeometry.IsValid)
    {
        myGeometry = SqlSpatialFunctions.MakeValid(myGeometry);
    }
