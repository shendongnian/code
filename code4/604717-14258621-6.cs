    var date = DateTime.Now.ToLocalTime();
    picThumbnail.ImageLocation = Folder + date.IsDayTime() ? "\\Day.bmp" : "\\Night.bmp";
    picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
    SystemParametersInfo(20, 0, Folder + "\\Day.bmp", 0x01 | 0x02);
    var rkWallPaper = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
    rkWallPaper.SetValue("WallpaperStyle", 2);
    rkWallPaper.SetValue("TileWallpaper", 0);
    rkWallPaper.Close();
