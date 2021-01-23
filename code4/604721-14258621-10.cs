    var date = DateTime.Now.ToLocalTime();
    var file = Path.Combine(Folder, date.IsDayTime() ? "Day.bmp" : "Night.bmp");
    picThumbnail.ImageLocation = file;
    picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
    SystemParametersInfo(20, 0, file, 0x01 | 0x02);
    var rkWallPaper = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
    rkWallPaper.SetValue("WallpaperStyle", 2);
    rkWallPaper.SetValue("TileWallpaper", 0);
    rkWallPaper.Close();
