    public static class TestUtils
    {
        public static string GetBaseDir()
        {
            return HttpContext.Current.Server.MapPath("~/");
        }
        public static string GetImagePath(string fileName)
        {
            return Path.Combine(GetBaseDir(), "Images", fileName);
        }
        public static string GetDataFilePath(string fileName)
        {
            return Path.Combine(GetBaseDir(), "Data", fileName);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetOutputFileName([CallerMemberName] string methodName = null)
        {
            return Path.Combine(GetOutputFolder(), $"{methodName}.pdf");
        }
        public static string GetOutputFolder()
        {
            var dir = Path.Combine(GetBaseDir(), "App_Data", "out");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }
        public static string GetWingdingFontPath()
        {
            return Path.Combine(GetBaseDir(), "fonts", "wingding.ttf");
        }
        public static string GetTahomaFontPath()
        {
            return Path.Combine(GetBaseDir(), "fonts", "tahoma.ttf");
        }
        public static string GetVerdanaFontPath()
        {
            return Path.Combine(GetBaseDir(), "fonts", "verdana.ttf");
        }
        public static Font GetUnicodeFont(
                    string fontName, string fontFilePath, float size, int style, BaseColor color)
        {
            if (!FontFactory.IsRegistered(fontName))
            {
                FontFactory.Register(fontFilePath);
            }
            return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, size, style, color);
        }
        public static void VerifyPdfFileIsReadable(byte[] file)
        {
            PdfReader reader = null;
            try
            {
                reader = new PdfReader(file);
                var author = reader.Info["Author"] as string;
                if (string.IsNullOrWhiteSpace(author) || !author.Equals("Vahid"))
                {
                    throw new InvalidPdfException("This is not a valid PDF file.");
                }
            }
            finally
            {
                reader?.Close();
            }
        }
        public static void VerifyPdfFileIsReadable(string filePath)
        {
            VerifyPdfFileIsReadable(File.ReadAllBytes(filePath));
        }
    }
