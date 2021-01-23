    /// <summary>
    /// Calculate the number of soft line breaks
    /// </summary>
    private static int GetSplittedLineCount(this XGraphics gfx, string content, XFont font, double maxWidth)
    {
        //handy function for creating list of string
        Func<string, IList<string>> listFor = val => new List<string> { val };
        // string.IsNullOrEmpty is too long :p
        Func <string, bool> nOe = str => string.IsNullOrEmpty(str);
        // return a space for an empty string (sIe = Space if Empty)
        Func<string, string> sIe = str => nOe(str) ? " " : str;
        // check if we can fit a text in the maxWidth
        Func<string, string, bool> canFitText = (t1, t2) => gfx.MeasureString($"{(nOe(t1) ? "" : $"{t1} ")}{sIe(t2)}", font).Width <= maxWidth;
        Func<IList<string>, string, IList<string>> appendtoLast =
                (list, val) => list.Take(list.Count - 1)
                                   .Concat(listFor($"{(nOe(list.Last()) ? "" : $"{list.Last()} ")}{sIe(val)}"))
                                   .ToList();
        var splitted = content.Split(' ');
        var lines = splitted.Aggregate(listFor(""),
                (lfeed, next) => canFitText(lfeed.Last(), next) ? appendtoLast(lfeed, next) : lfeed.Concat(listFor(next)).ToList(),
                list => list.Count());
        return lines;
    }
