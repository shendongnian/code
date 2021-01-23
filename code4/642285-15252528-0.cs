    var paths = new Dictionary<string, string> {
            {"default_music", @"C:\Users\Public\Music\Sample Music"},
            {"alternative_folder", @"C:\tmp"}
         };
    MusicList.ItemsSource = paths.Values.Select(p => new DirectoryInfo(p))
                                 .SelectMany(d => d.EnumerateFiles("*.mp3"));
