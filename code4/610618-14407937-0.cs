    string Remove(string s, char begin, char end)
    {
        Regex regex = new Regex(string.Format("\\{0}.*?\\{1}", begin, end));
        return regex.Replace(s, string.Empty);
    }
    
    
    string s = "Hello (my name) is (brian)"
    s = Remove(s, '(', ')');
