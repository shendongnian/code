    [Table("WIDGETENTITIES")]
    public class WidgetEntity {
        [Column("WIDGETENTITY_ID")]
        public int Id { get; set; }
        [InverseProperty("WidgetEntities")]
        public WidgetSequence Sequence { get; set; }
        // and other properties that map correctly
    }
    [Table("WIDGETSEQUENCES")]
    public class WidgetSequence { 
        [Column("WIDGETSEQUENCE_ID")]
        public int Id { get; set; }
        [Column("NUMBER")]
        public int Number { get; set; }
        public virtual List<WidgetEntity> WidgetEntities { get; set; }
    }
