    [Table("tblCollectionsList")]
    public class CollectionsList
    {
    [Key]
    public byte ListID {get;set;}
    public byte SectionID {get;set;}
    public byte IncludedSectionID {get;set;}
    
    [ForeignKey("SectionID")]
    public virtual Section Section {get;set;}
    [ForeignKey("IncludedSectionID")]
    public virtual Section IncludedSection {get;set;}
    
    }
