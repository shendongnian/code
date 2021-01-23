    //Set up our sample Dictionary
    Dictionary<string, string> settings = new Dictionary<string,string>();
    settings.Add("books_book1","a");
    settings.Add("books_book2","b");
    settings.Add("books_book3","c");
    //Write the values to file via an intermediate stringbuilder.    
    StringBuilder sb = new StringBuilder();
    foreach (var item in settings)
    {
    	sb.AppendLine(String.Format("{0} = {1}", item.Key, item.Value));
    }
    
    File.WriteAllText("settings.txt", sb.ToString());
