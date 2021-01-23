    private string TrackStats(string thing, string variable)
    {
        if (!(thing.Contains(variable)))
        {
            thing += variable + ",";
        }         
        return thing;  
    }
