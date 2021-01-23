	public ActionResult Image(string id)
	{
	    var dir = Server.MapPath("/Images");
	    var path = Path.Combine(dir, id + ".jpg");
	    return base.File(path, "image/jpeg");
	}
