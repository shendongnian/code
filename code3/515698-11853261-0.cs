    Dictionary<char, int> d = new Dictionary<char, int>();
    foreach(char c in a){
        if(d.ContainsKey(c)){
            d[c] = d[c] + 1;
        } else {
            d[c] = 1;
        }
    }
    StringBuilder sb = new StringBuilder();
    foreach(KeyValuePair p in d){
        sb += p.Key.ToString() + p.Value.Tostring();
    }
    return sb.ToString();
