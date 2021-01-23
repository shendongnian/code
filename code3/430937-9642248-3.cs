    public class CVehicleView : CompositeDataBoundControl
    {
        public object VehicleDataSource {get; set;}
        
        public new object DataSource
        {
           get { return new List<object>{ VehicleDataSource };}
           private set {;}
        }
    }
