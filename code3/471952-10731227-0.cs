    public ActionResult Add(ShapeInputModel dto, FormCollection collection)
    {
        var model = new GeoRegions();
        if (TryUpdateModel(model))
        {
            var destinationFolder = Server.MapPath("/App_Data/KML");
            var postedFile = dto.Shape;
            if (postedFile != null)
            {
                var fileName = Path.GetFileName(postedFile.FileName);
                var path = Path.Combine(destinationFolder, fileName);
                postedFile.SaveAs(path);
                //Save to Database
                Db.AddGeoRegions(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        return null; // you can change the null to anything else also.
    }
