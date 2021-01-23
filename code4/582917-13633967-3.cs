         Dictionary<string, Bitmap> images = new Dictionary<string, Bitmap>();
    
            string[] extensions = new string[]{".BMP",".JPG",".GIF",".PNG"};
            var fd = new System.Windows.Forms.FolderBrowserDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var file in Directory.GetFiles(fd.SelectedPath).Where(f => extensions.Contains(Path.GetExtension(f).ToUpper())))
                {
                    images.Add(Path.GetFileNameWithoutExtension(file), new Bitmap(file));
                }
            }
