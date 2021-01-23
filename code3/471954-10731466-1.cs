    public ActionResult Add(ShapeInputModel dto, FormCollection collection)
    {
        var model = new GeoRegions();
        if (TryUpdateModel(model))
        {
         ....
         ....
        }
        return default_value;//it may be in else condition also.
    }
