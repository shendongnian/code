    public string ExtractDateTimeString(string s){
        return s.Split(' ').Where(x => 
                {
                    DateTime o;
                    return DateTime.TryParse(x, out o);
                }).FirstOrDefault();
    }
