    public bool SpacelessCompare(string a, string b){
        string compareA = a.Replace(Environment.NewLine, "").Replace(" ", "");
        string compareB = b.Replace(Environment.NewLine, "").Replace(" ", "");
    
        return compareA == compareB;
    }
