    public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
    {
            int place = Source.LastIndexOf(Find);
            
            if(place == -1)
               return string.Empty;
               
            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
    }
