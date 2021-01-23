    public class Detail
    {
        public Detail()
        {
            this.ColumnCtrl = new List<UserControl>();
        }
        private List<UserControl> columnCtrl = null;
        public List<UserControl> ColumnCtrl
        {
            get 
            {
                // Missing appropriate locking mechanisms for brevity
                if (columnCtrl == null)
                    columnCtrl = new List<UserControl>();
                return columnCtrl;
            }
            // The set is not absolutely necessary if you never need to set it
            // from outside of Details but if you do...
            set
            {
                columnCtrl = value;
            }
        }
    }
