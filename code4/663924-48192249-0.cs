    int count = Directory.EnumerateFiles(System.Web.HttpContext.Current.Server.MapPath("~/images/savedimages"), "*").Count();
    var img = Base64ToImage(imgRaw);
    string path = "images/savedimages/upImages" + (count + 1) + ".png";
    img.Save(Path.Combine(System.Web.HttpContext.Current.Server.MapPath(path)));
    return path;
