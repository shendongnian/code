    private IEnumerable<LineMatch> ScanDocuments2()
    {
        string[] keywordtext = txtKeywords.Lines;
        string[] patterntext = txtPatterns.Lines;
        Regex searchPattern = GetSearchPattern();
        var keywords = GetKeywords(keywordtext).ToList();
        var patterns = GetPatterns(patterntext).ToList();
        try
        {
            var files = GetFiles(searchPattern);
            
            var lines = files.Aggregate(
                   new List<LineMatch>(),
                   (accumulator, file) =>
                   {
                    foreach(var item in EnumerateFile(file, keywords, patterns))
                    {
                      accumulator.Add(item);
                    }
                       
                       return accumulator;
                   },
                   accumulator => accumulator
            );
            return lines;
        }
        catch (UnauthorizedAccessException UAEx)
        {
            Console.WriteLine(UAEx.Message);
            throw;
        }
        catch (PathTooLongException PathEx)
        {
            Console.WriteLine(PathEx.Message);
            throw;
        }
    }
    private LineMatch EnumerateFile(string file, IEnumerable<string> keywords, IEnumerable<Regex> patterns)
    {
      var counter = 0;
      foreach(var line in File.ReadLines(file))
      {
        var matchingRegex = patterns.FirstOrDefault(p => p.IsMatch(line));
        var keyword = keywords.FirstOrDefault(k => line.ToLower().Contains(k.ToLower()));
        if(keyword == null && matchingRegex == null) continue;
        string tmpfile = file.Replace(txtSelectedDirectory.Text, "..");
        yield return new LineMatch
        {
            Counter = counter,
            File = tmpfile,
            Line = line,
            Pattern = matchingRegex == null ? null : matchingRegex.Pattern,
            Keyword = keyword
        };
        counter++;
      }
    }
    private IEnumerable<string> GetFiles(Regex searchPattern)
    {
      return Directory.EnumerateFiles(txtSelectedDirectory.Text, "*.*", SearchOption.AllDirectories).Where(f => searchPattern.IsMatch(f));
    }
    private IEnumerable<string> GetKeywords(IEnumerable<string> keywordtext)
    {
      foreach(var keyword in keywordtext)
      {
        if(keyword.Length <= 0) continue;
        yield return keyword;
      }
    }
    private IEnumerable<string> GetPatterns(IEnumerable<string> patterntext)
    {
      foreach(var pattern in patterntext)
      {
        if(pattern.Length <= 0) continue;
        yield return new Regex(pattern);
      }
    }
    private Regex GetSearchPattern()
    {
      return new Regex(string.Format(@"$(?<=\.({0}))",  txtFilePattern.Text), RegexOptions.IgnoreCase);
    }
    public class LineMatch
    {
      public int Counter { get; set; }
      public string File { get; set; }
      public string Line { get; set; }
      public string Pattern { get; set; }
      public string Keyword { get; set; }
    }
