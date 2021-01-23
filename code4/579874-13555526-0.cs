    DateTime? hD = null;
    if(!string.IsNullOrWhitespace(hire )) // string.IsNullOrEmpty if on .NET pre 4.0
    {
       hD = DateTime.Parse(hire);            
    }
