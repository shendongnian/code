    string pattern = string.Format("(^|\\s){0}(\\s|$)", Regex.Escape(fileName));
    Regex regex = new Regex(pattern);
    
    string listing = reader.ReadToEnd();
    bool exists = regex.IsMatch(listing);
