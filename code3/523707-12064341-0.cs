    public IEnumerable<IEnumerable<Line>> Bundle(IEnumerable<Line> Lines)
    {
        return Lines
            .Where(x => x.PropertyOne == "A" )
            .GroupBy(x => new {x.PropertyTwo, x.PropertyThree});
    }
