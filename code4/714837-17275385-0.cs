    internal class DataGridViewClasses{
        public class DataGridViewPercentageColumn : DataGridViewColumn
        {
            public DataGridViewPercentageColumn() : base(new DataGridViewPercentageCell())
            {
            }
        }
        public class DataGridViewPercentageCell : DataGridViewTextBoxCell
        {
            public DataGridViewPercentageCell()
            {
                this.Style.Format = "0%";
            }
        }
    }
