    public override bool Equals(object obj)
    {
        return Math.Abs(ID - ((Person)obj).ID) <= 5; 
    }
    public override int GetHashCode()
    {
        return 0;
    }
