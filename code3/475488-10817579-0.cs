    public class CustomColumn : DataGridViewColumn {
      public CustomColumn()
        : base(new DataGridViewTextBoxCell()) {
      }
      [DisplayName("Type")]
      [Category("Custom Property")]
      public String type { get; set; }
      public override object Clone() {
        CustomColumn copy = base.Clone() as CustomColumn;
        copy.type = type;
        return copy;
      }
    }
