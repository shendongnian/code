    /// <summary>
    /// Parses the string for css imports and adds them to the file dependency 
    /// list.
    /// </summary>
    /// <param name="css">
    /// The css to parse for import statements.
    /// </param>
    /// <param name="minify">Whether or not the local script should be minified.
    ////</param>
    /// <returns>The css file parsed for imports.</returns>
    private string ParseImportsAndCache(string css, bool minify)
    {
        // Check for imports and parse if necessary.
        if (!css.Contains("@import", StringComparison.OrdinalIgnoreCase))
        {
            return css;
        }
    
        // Recursivly parse the css for imports.
        foreach (Match match in ImportsRegex.Matches(css))
        {
            // Recursivly parse the css for imports.
            GroupCollection groups = match.Groups;
            Capture fileName = groups["filename"].Captures[0];
            CaptureCollection mediaQueries = groups["media"].Captures;
            Capture mediaQuery = null;
    
            if (mediaQueries.Count > 0)
            {
                mediaQuery = mediaQueries[0];
            }
    
            // Check and add the @import params to the cache dependancy list.
            // Get the match
            List<string> files = CSSPaths
                .SelectMany(cssPath => Directory.GetFiles(
                    HttpContext.Current.Server.MapPath(cssPath),
                    Path.GetFileName(fileName.ToString()),
                    SearchOption.AllDirectories))
                .ToList();
    
            string file = files.FirstOrDefault();
            string thisCSS = string.Empty;
    
            // Read the file.
            if (file != null)
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    thisCSS = mediaQuery != null
                        ? string.Format(CultureInfo.InvariantCulture,
                                    "@media {0}{{{1}{2}{1}}}",
                                    mediaQuery,
                                    Environment.NewLine,
                                    this.ParseImportsAndCache(
                                    this.PreProcessInput(reader.ReadToEnd(), 
                                    file),
                                    minify))
                        : this.ParseImportsAndCache(this.PreProcessInput(
                                                    reader.ReadToEnd(), 
                                                    file), 
                                                    minify);
                }
            }
    
            // Replace the regex match with the full qualified css.
            css = css.Replace(match.Value, thisCSS);
    
            if (minify)
            {
                this.cacheDependencies.Add(new CacheDependency(
                                               files.FirstOrDefault()));
            }
        }
    
        return css;
    }
