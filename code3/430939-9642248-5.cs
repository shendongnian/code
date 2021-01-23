    public class CVehicleView : CompositeDataBoundControl
    {
        private object dataSource;
        public override object DataSource
        {
            get { return new List<object> { dataSource }; }
            set { dataSource = value; }
        }
    }
