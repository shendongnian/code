    var consuming = false;
    var routingOutline = new List<decimal>();
    Func<string, bool> isDecimal = text =>
        {
            decimal d;
            return decimal.TryParse(text, out d);
        };
    foreach (var line in File.ReadLines("data.txt"))
    {
        if (line.Contains("BOARD_PLACEMENT_OUTLINE"))
            break;
        if (line.Contains("BOARD_ROUTING_OUTLINE"))
            consuming = true;
        if (consuming)
        {
            var outlineValues = line.Split(' ')
                                    .Where(isDecimal)
                                    .Select(decimal.Parse);
            routingOutline.AddRange(outlineValues);
        }
    }
