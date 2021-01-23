    public void main()
    {
      lstChapters.DataContext = await LoadChapters();
    }
    internal static Task<List<dictChapters>> LoadChapters()
    {
      return TaskEx.Run(delegate
      {
        var element = XElement.Load("xml/chapters.xml");
        IEnumerable<dictChapters> Chapters =  
            from var in element.Descendants("chapter")
            orderby var.Attribute("index").Value
            select new dictChapters
            {
              ChapterIndex = Convert.ToInt32(var.Attribute("index").Value),
              ChapterArabicName = var.Attribute("name").Value,
              ChapterType = var.Attribute("type").Value,
            };
        return Chapters.ToList();
      });
    }
