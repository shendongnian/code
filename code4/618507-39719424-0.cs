    public class ZoomDataVm : ModelBase
    {
        public ZoomDataVm()
        {
            // initialise the zoom
        }
    
        private double _zoomLevel;
        public double ZoomLevel
        {
            get { return _zoomLevel; }
            set
            {
                if (_zoomLevel != value)
                {
                    _zoomLevel = value;
                    RaisePropertyChanged(() => ZoomLevel);
                    //
                    // persist zoom info
                }
            }
        }
    }
        
    public class ZoomVm : ModelBase
    {
        public static ZoomDataVm _instance;
    
        static ZoomVm()
        {
            _instance = new ZoomDataVm();
        }
    
        public ZoomDataVm Instance
        {
            get { return _instance; }
        }
    }
