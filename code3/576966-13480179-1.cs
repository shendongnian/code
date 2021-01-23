    public static IEnumerable<string> GetImages()
            {
                var pathRegEx = new Regex(@"\\images\\Job[\d]+Images\\", RegexOptions.Compiled);
    
                foreach (var path in FileSystem.GetFiles(@"\\server\Scanner\images", SearchOption.SearchAllSubDirectories, new string[] { "*.*" }))
                {
                    if (pathRegEx.IsMatch(path))
                    {
                        yield return path;
                    }
                }
            }
