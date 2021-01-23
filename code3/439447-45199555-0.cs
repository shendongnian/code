    public static class Helper
        {
            public static string GetFileExtention(this OpenFileDialog dialog)
            {
                return Path.GetExtension(dialog.FileName);
            }
        }
