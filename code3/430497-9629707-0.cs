    public bool Equals(WeekOfYear other)
    {
        return other != null && Year == other.Year && Week == other.Week;
    }
    public override bool Equals(object obj)
    {
        return Equals(obj as WeekOfYear);
    }
    public override int GetHashCode()
    {
        return (Year.GetHashCode()*31) + Week.GetHashCode();
    }
