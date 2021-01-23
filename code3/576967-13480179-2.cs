    public static IEnumerable<string> GetImages()
            {
                var pathRegEx = new Regex(@"\\images\\Job[\d]+Images\\", RegexOptions.Compiled);
    
                foreach (var path in Directory.EnumerateFiles(@"\\server\Scanner\images", "*.*", SearchOption.AllDirectories))
                {
                    if (pathRegEx.IsMatch(path))
                    {
                        yield return path;
                    }
                }
            }
