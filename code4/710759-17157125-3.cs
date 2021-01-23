    public string AddComment(string inputHtml)
    {
    int index = inputHtml.IndexOf("</body>");
    return inputHtml.Insert(index-1,  new Comment("New comment header", "New comment Body"));
    }
