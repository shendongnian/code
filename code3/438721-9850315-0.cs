    public override object Clone() 
    {
        var clonedColumn = base.Clone() as CustomColumn;
        clonedColumn.CustomProp = this.CustomProp;
        return clonedColumn;
    }
