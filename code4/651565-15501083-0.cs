     public override int GetHashCode()
    {
        return this.Coordinate.GetHashCode();
    }
     ....
    public override int GetHashCode()
    {
        return  this.Column.GetHashCode() * 17 + this.Row.GetHashCode();
    }    
     ....
    public override int GetHashCode()
    {
        return this.Grid.GetHashCode();
    }
