    public class CustomColumn : DataGridViewColumn
    {
        public CustomColumn() : base(new CustomeCell()) { }
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value != null && !value.GetType()
                    .IsAssignableFrom(typeof (CustomeCell)))
                    throw new InvalidCastException("It should be a custom Cell");
                base.CellTemplate = value;
            }
        }
    }
