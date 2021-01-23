    private void TrackStats(ref string thing, string variable)
    {
        if (!(thing.Contains(variable)))
        {
            thing += variable + ",";
        }           
    }
