    internal static async Task<IEnumerable<dictChapters>> LoadChapters()
    {
      var element = XElement.Load("xml/chapters.xml");
      Task<IEnumerable<dictChapters>> something = TaskEx.Run(delegate
      {
        IEnumerable<dictChapters> Chapters =  
           from var in element.Descendants("chapter")
           orderby var.Attribute("index").Value
           select new dictChapters
           {
              ChapterIndex = Convert.ToInt32(var.Attribute("index").Value),
              ChapterArabicName = var.Attribute("name").Value,
              ChapterType = var.Attribute("type").Value,
           };
         return Chapters;
      });
      var results = await something;
      return results;
    }
