    public bool SpacelessCompare(string a, string b){
        string compareA = a.replace(Environment.NewLine, "").Replace(" ", "");
        string compareB = b.replace(Environment.NewLine, "").Replace(" ", "");
    
        return compareA == compareB;
    }
