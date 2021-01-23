            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(ShellFolder.DocumentsFolder() + System.IO.Path.DirectorySeparatorChar + screenshot.Filename);
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.EndInit();
            imgScreenshot.Source = bi;
            File.Delete(ShellFolder.DocumentsFolder() + System.IO.Path.DirectorySeparatorChar + screenshot.Filename);
