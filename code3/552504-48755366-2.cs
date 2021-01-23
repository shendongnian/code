    /// <summary>
    /// Application header, also sets the console title
    /// </summary>
    /// <param name="title">Title of application</param>
    /// <param name="subtitle">Subtitle of application</param>
    /// <param name="foreGroundColor">Foreground color</param>
    public static void Header(string title, string subtitle = "", ConsoleColor foreGroundColor = ConsoleColor.White, int windowWidthSize = 90)
    {
    	Console.Title = title + (subtitle != "" ? " - " + subtitle : "");
    	string titleContent = CenterText(title, "║");
    	string subtitleContent = CenterText(subtitle, "║");
    	string borderLine = new String('═', windowWidthSize - 2);
    
    	Console.ForegroundColor = foreGroundColor;
    	Console.WriteLine($"╔{borderLine}╗");
    	Console.WriteLine(titleContent);
    	if (!string.IsNullOrEmpty(subtitle))
    	{
    		Console.WriteLine(subtitleContent);
    	}
    	Console.WriteLine($"╚{borderLine}╝");
    	Console.ResetColor();
    }
    
    /// <summary>
    /// Align content to center for console. Can be used with decoration if used inside menu or header
    /// </summary>
    /// <param name="content">Content to center</param>
    /// <param name="decorationString">Left and right decoration, default is empty/none</param>
    /// <returns>Center aligned text</returns>
    public static string CenterText(string content, string decorationString = "", int windowWidthSize = 90)
    {
    	int windowWidth = windowWidthSize - (2 * decorationString.Length);
    	return String.Format(decorationString + "{0," + ((windowWidth / 2) + (content.Length / 2)) + "}{1," + (windowWidth - (windowWidth / 2) - (content.Length / 2) + decorationString.Length) + "}", content, decorationString);
    }
