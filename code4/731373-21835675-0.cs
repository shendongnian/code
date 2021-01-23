    private static string SupportedImageDecodersFilter()
    {
        // ext = "*.BMP;*.DIB;*.RLE"           descr = BMP
        // ext = "*.JPG;*.JPEG;*.JPE;*.JFIF"   descr = JPEG
        // ext = "*.GIF"                       descr = GIF
        // ext = "*.TIF;*.TIFF"                descr = TIFF
        // ext = "*.PNG"                       descr = PNG
        ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
        string allExtensions = encoders
            .Select(enc => enc.FilenameExtension)
            .Join(";")
            .ToLowerInvariant();
        var sb = new StringBuilder(500)
            .AppendFormat("Image files  ({0})|{1}", allExtensions.Replace(";", ", "),
                          allExtensions);
        foreach (ImageCodecInfo encoder in encoders) {
            string ext = encoder.FilenameExtension.ToLowerInvariant();
            string caption;
            switch (encoder.FormatDescription) {
                case "BMP":
                    caption = "Windows Bitmap";
                    break;
                case "JPEG":
                    caption = "JPEG file";
                    break;
                case "GIF":
                    caption = "Graphics Interchange Format";
                    break;
                case "TIFF":
                    caption = "Tagged Image File Format";
                    break;
                case "PNG":
                    caption = "Portable Network Graphics";
                    break;
                default:
                    caption = encoder.FormatDescription;
                    break;
            }
            sb.AppendFormat("|{0}  ({1})|{2}", caption, ext.Replace(";", ", "), ext);
        }
        return sb.ToString();
    }
