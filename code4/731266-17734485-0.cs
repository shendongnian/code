            var path = Directory.EnumerateFiles(HttpContext.Current.Server.MapPath("~/Assets/Images/"), string.Format("{0}.*", id), SearchOption.TopDirectoryOnly).FirstOrDefault();
            switch (Path.GetExtension(path))
            {
                case ".png":
                case ".jpg":
                case ".gif":
                    break;
                default:
                    return;
            }
