    public string ParseCriteria( Criteria criteria ) {
        string result = "(";
        result += criteria.Display;
        foreach( var criteria in criteria.Criteria) {
            result += ParseCriteria( criteria )
        }
        return result;
    }
