    private string ReplaceFirstOccurrence(string Source, string Find, string Replace)
    {
     int Place = Source.IndexOf(Find);
     string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
     return result;
    }
    
    var result =ReplaceFirstOccurrence(text,"~"+input,"");
