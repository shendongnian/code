    MainTable
    ---------
    MainTableId
    DatabaseName
    ExtendedTable
    ----------
    NotTheSameName
    AnotherColumn
    public class MainTable
    {
     [Key]
     public int MainTableId { get; set; }
     public string DatabaseName { get; set; }
     [InverseProperty("MainTable")]
     public virtual ExtendedTable ExtendedTable { get; set; }
    }
    public class ExtendedTable
    {
     [Key]
     public int NotTheSameName { get; set; }
     public string AnotherColumn { get; set; }
     [ForeignKey("NotTheSameName")]
     public virtual MainTable MainTable { get; set; }
    }
