    private static Random random = new Random();
    private static List<string> colors = new List<string> { ... };
    private static string ChooseColor()
    {
        if (colors.Count > 0)
        {
            int index = random.Next(colors.Count);
            string colorName = colors[index];
            colors.RemoveAt(index);
            return colorName;
        }
        return String.Empty;
    }
