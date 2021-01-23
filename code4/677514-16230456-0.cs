    public class UploadFiles
    {
        public static void EnsureDirectoriesExist(string SKU)
        {
            // if the directory doesn't exist - create it. 
            if (!System.IO.Directory.Exists("//servername/wwwroot/prodimg/" + SKU))
            {
                System.IO.Directory.CreateDirectory("//servername/wwwroot/prodimg/" + SKU);
            }
        }
    }
