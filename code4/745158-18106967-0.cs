    public string GetTime(Object obj, string propName)
    {
       TimeSpan? time = obj.GetType().GetProperty(propName).GetValue(obj, null);
       
       // The difference is here... If time has a value, then take it
       // and format it, otherwise return an empty string.
       return time.HasValue ? time.Value.ToString(@"hh\:mm") : string.Empty;
    }
