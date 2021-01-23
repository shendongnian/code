    var actions = new[]
    {
     new {
      index = 0, 
      uri = "Resources/Games/MaxPayne3/StoryRelated.txt", 
      guide = "Story Complete [MEDIUM]\n\n", 
      title = "Feel The Payne", 
      appBar = false, 
      youtube = ""
     },
     new {
      index = 7, 
      uri = "Resources/Games/MaxPayne3/TextFile2.txt", 
      guide = "", 
      title = "A New York Minute", 
      appBar = false, 
      youtube = ""
     },
     new {
      index = 9, 
      uri = "Resources/Games/MaxPayne3/TextFile4.txt", 
      guide = "", 
      title = "Out The Window", 
      appBar = true, 
      youtube = "http://www.youtube.com/watch?v=lRg6ygA-M_Y"
     },
    };
    var actionQuery = actions.Where(a => a.index == selectedIndex).ToArray();
    if (actionQuery.Length == 0) throw new Exception("Index not found: " + selectedIndex);
    if (actionQuery.Length > 1) throw new Exception("Duplicate entries found: " + selectedIndex);
    var action = actionQuery[0];
    var Tutorial = Application.GetResourceStream(new Uri(action.uri, UriKind.Relative));
    using (Stream Text = Tutorial.Stream)
    {
     StreamReader sr = new StreamReader(Text);
     Guide.Text = action.guide + sr.ReadToEnd();
     Title.Text = action.title;
     AppBarMenuDisable.IsEnabled = action.appBar;
     if (action.youtube != "") YouTubeLink.URL = action.youtube;
    }
