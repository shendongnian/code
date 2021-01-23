    // Assume the Tuples are <height, width>
    string DrawRectangles(params Tuple<int, int>[] measurements)
    {
        var sb = new StringBuilder();
        var maxHeight = measurements.Max(measurement => measurement.Item1);
        for (var h = maxHeight; h > 0; h--)
        {
            foreach (var measurement in measurements)
            {
                // If you're on the top or bottom row of a rectangle...
                if (h == 0 || measurement.Item1 == h)
                {
                    sb.Append(String.Format("{0}{1}{0}", "+", new String('-', measurement.Item2 - 2)));
                    continue;
                }
            
                // If you're in the middle of a rectangle...
                if (measurement.Item1 > h)
                {
                    sb.Append(String.Format("{0}{1}{0}", "+", new String(' ', measurement.Item2 - 2)));
                    continue;
                }
                sb.Append(new String(' ', measurement.Item2));
            }
            sb.Append(Environment.NewLine);
        }
        return sb.ToString();
    }
