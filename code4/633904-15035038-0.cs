    using(var pic = System.Drawing.Image.FromFile(Server.MapPath(url)))
    {
        pic.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
        pic.Save(Server.MapPath(url));
    }
