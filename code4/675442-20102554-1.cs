    WalkNode(json, null, prop =>
    {
         if (prop.Name == "Title" && prop.Value.Type == JTokenType.String)
         {
             string title = prop.Value<string>();
             Console.WriteLine(title);
         }
    });
