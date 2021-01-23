    public static string RenderPartialViewToString(string templatePath, string templateName, object viewModel)
    {
        string text = File.ReadAllText(Path.Combine(templatePath, templateName));
        string renderedText = Razor.Parse(text, viewModel);
        return renderedText;
    }
