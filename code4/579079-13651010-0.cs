    var text = "";
    var sizes = new System.Collections.Generic.List<double>();
    for (int i = 1; i <= 50; i++)
    {
        text += (i % 10).ToString();
        var ts = TextRenderer.MeasureText(text, this.Font);
        sizes.Add((ts.Width * 1.0) / text.Length);
    }
    sizes.Add(sizes.Average());
    Clipboard.SetText(string.Join("\r\n",sizes));
