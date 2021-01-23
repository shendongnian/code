    [Table("WIDGETENTITIES")]
    public class WidgetEntity {
        [Column("WIDGETENTITY_ID")]
        public int Id { get; set; }
        [ForeignKey("Sequence")] //Has to be a property name, not table column name
        [Column("WIDGETSEQUENCE_ID")]
        public int WidgetSequenceId { get; set; }
        public WidgetSequence Sequence { get; set; }
        // and other properties that map correctly
    }
    [Table("WIDGETSEQUENCES")]
    public class WidgetSequence { 
        [Column("WIDGETSEQUENCE_ID")]
        public int Id { get; set; }
        [Column("NUMBER")]
        public int Number { get; set; }
    }
