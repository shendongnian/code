    public ActionResult SearchImage(string id)
    {
        var path = @"\\jesus-pc\Frontera\IMAGENES\SINGNOS DISTINTIVOS\0\80HP23891268272.TIF";
        return base.File(path, "image/jpeg");
    }
