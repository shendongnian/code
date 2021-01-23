    public static Image RenderToImage<T>(String fullViewName, T model)
    {
        String html = RenderViewToString(fullViewName, model);
        var image = HtmlRender.RenderToImage(html);
        return image;
    }
    
    public static String RenderViewToString<T>(String fullViewName, T model)
    {
        String viewText = File.ReadAllText(fullViewName);
        String renderedText = Razor.Parse(viewText, model); // RazorEngine here. I don't have MVC
        return renderedText;
    }
