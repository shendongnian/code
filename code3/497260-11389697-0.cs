    public virtual IDictionary<Column, Cell> Cells { get; private set; }
    HasMany(m => m.Cells)
        .Table("Cells")
        .KeyColumn("Row_Id")
        .AsEntityMap("Column_id")
        .Inverse().Cascade.All();
