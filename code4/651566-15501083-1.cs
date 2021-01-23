    //Field 
    public override int GetHashCode()
    {
        return this.Coordinate.GetHashCode();
    }
    //Coordinate 
    public override int GetHashCode()
    {
        return  this.Column.GetHashCode() * 17 + this.Row.GetHashCode();
    }    
    
    //Sudoku, I doubt if this is ever called...
    public override int GetHashCode()
    {
        return this.Grid.GetHashCode();
    }
